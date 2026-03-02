using Data.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Entities.Auth;
using Results;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;
using Services.Validators;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        private readonly ICustomerRepository _customerRepository;

        private readonly ITokenService _tokenService;

        private readonly UserManager<FoodRushIdentityUser> _userManager;

        public AuthService(
            IAuthRepository repository,
            ICustomerRepository customerRepository,
            ITokenService tokenService,
            UserManager<FoodRushIdentityUser> userManager)
        {

            _repository = repository;
            _customerRepository = customerRepository;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<Result<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            FoodRushIdentityUser? user = await _repository.GetByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Result<LoginResponseDto>.Fail("Invalid email or password", Results.Enums.ResultFailureType.Authentication);
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordCorrect)
            {
                return Result<LoginResponseDto>.Fail("Invalid email or password", Results.Enums.ResultFailureType.Authentication);
            }

            string accessToken = await _tokenService.GenerateAccessTokenForUser(user);
            RefreshTokenWithRawDto refreshToken = await _tokenService.GenerateAndRotateRefreshTokenForUser(user, "Replaced by new token at login");

            return Result<LoginResponseDto>.Ok(new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            });
        }

        public async Task<Result<RegisterResponseDto>> RegisterAsync(RegisterDto registerDto)
        {
            RegisterValidator validator = new RegisterValidator();

            ValidationResult valResult = validator.Validate(registerDto);
            if (!valResult.IsValid)
            {
                return Result<RegisterResponseDto>.ValidationFail(valResult.Errors);
            }

            FoodRushIdentityUser? user = await _repository.FindByEmailOrUserNameAsync(registerDto.UserName, registerDto.Email);
            Customer? existingCustomer = await _customerRepository.GetByEmailAsync(registerDto.Email);
            if (user != null || existingCustomer != null)
            {
                return Result<RegisterResponseDto>.Fail("User already exist", Results.Enums.ResultFailureType.BusinessRuleViolation);
            }

            Customer customer = new Customer
            {
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                LastName = registerDto.LastName,
                FirstName = registerDto.FirstName,
            };

            FoodRushIdentityUser identityUser = new FoodRushIdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
            };

            try
            {
                customer = await _customerRepository.AddAsync(customer);

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, registerDto.Password);
                if (!identityResult.Succeeded)
                {
                    throw new Exception(string.Join(", ", identityResult.Errors.Select(e => e.Description)));
                }

                return Result<RegisterResponseDto>.Ok(new RegisterResponseDto
                {
                    Id = customer.Id,
                    Email = registerDto.Email,
                    Phone = registerDto.Phone,

                });
            }
            catch (Exception ex)
            {
                await _customerRepository.DeleteAsync(customer);
                await _userManager.DeleteAsync(identityUser);

                return Result<RegisterResponseDto>.Fail("Registration failed due to a system error", Results.Enums.ResultFailureType.TransactionFailure);
            }
        }
    }
}
