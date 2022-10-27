using System.Text;

namespace JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "Alperalperalper1.";
        public const int Expire = 30;
    }
}
