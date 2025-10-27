using primerApi.Abstraccions;

namespace primerApi.Configuration
{
    public class TokeParameters : ITokenParameters
    {
        public string UserName { get ; set; }
        public string PasswordHash { get ; set ; }
        public string Id { get; set; }
    }
}
