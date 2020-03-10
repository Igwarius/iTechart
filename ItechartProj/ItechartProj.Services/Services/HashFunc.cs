using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Controllers
{
    public class HashFunc
    {
        public static string GetHashFromPassword(string str)
        {
            var data = new UTF8Encoding().GetBytes(str);
            SHA256 shaM = new SHA256Managed();
            var resultPassword = shaM.ComputeHash(data);
            var finalPassword = BitConverter.ToString(resultPassword).Replace("-", "").ToLower();
            return finalPassword;
        }
    }
}
