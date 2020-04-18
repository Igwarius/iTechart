using System;
using System.Security.Cryptography;
using System.Text;

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