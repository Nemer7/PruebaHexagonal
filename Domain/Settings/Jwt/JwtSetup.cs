using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Domain.Settings.Jwt
{
    public class JwtSetup: IConfigureOptions<JwtConfiguration>
    {
        private const string ConfigurationSectionName = "JwtSettings";
        private readonly IConfiguration _configuration;

        public JwtSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtConfiguration options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }


    }
}
