namespace JwtApp.Back.Core.Application.Dto
{
    public class CheckUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty ;
        public int Id { get; set; }
        public bool IsExist { get; set; }
    }
}
