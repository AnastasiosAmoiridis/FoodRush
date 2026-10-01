namespace FoodRush.Helpers
{
    public static class Cookies
    {
        public static void SetAccessTokenHttpOnly(HttpResponse response, string accessToken, DateTime? expires)
        {
            response.Cookies.Append("AccessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = expires ?? DateTime.Now.AddMinutes(15)

            });
        }
    }
}
