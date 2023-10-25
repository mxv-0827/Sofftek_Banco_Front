using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class TokenService //Token will be storaged here.
    {
        public string _token { get; private set; }

        public void SetToken(string token) => _token = token;
    }
}
