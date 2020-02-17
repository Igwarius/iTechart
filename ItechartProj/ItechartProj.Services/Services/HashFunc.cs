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
            byte[] data = new UTF8Encoding().GetBytes(str);
            byte[] resultPassword; SHA256 shaM = new SHA256Managed();
            resultPassword = shaM.ComputeHash(data);
            string FinalPassword = BitConverter.ToString(resultPassword).Replace("-", "").ToLower();
            return FinalPassword;
        }
    }
}
