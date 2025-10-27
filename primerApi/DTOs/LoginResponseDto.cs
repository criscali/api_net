namespace primerApi.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public bool Login { get; set; }
        public List<string> Errors { get; set; }
    }
}
