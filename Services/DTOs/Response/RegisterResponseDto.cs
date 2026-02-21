namespace Services.DTOs.Response
{
    public class RegisterResponseDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
