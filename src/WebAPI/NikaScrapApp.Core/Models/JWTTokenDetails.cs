using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models
{
    public class JWTTokenDetails: Response
    {
        public string TokenType { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; } 
    }
}
