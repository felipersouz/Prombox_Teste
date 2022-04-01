using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Prombox.Web.Settings
{
    public class SigningConfiguration
    {
        private readonly IConfiguration _configuration;

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

            /*using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }*/

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("General").GetSection("Secret").Value);
            Key = new SymmetricSecurityKey(key);
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
