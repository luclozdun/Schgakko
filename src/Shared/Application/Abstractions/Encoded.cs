using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Application.Abstractions
{
    public class Encoded
    {
        private IConfiguration Configuration;
        private string Hash;

        public Encoded(IConfiguration configuration)
        {
            Configuration = configuration;
            Hash = Configuration.GetSection("Encrypt").Get<string>();
        }

        public string Encrypt(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            string encrypt = Convert.ToBase64String(result);
            return encrypt;
        }

        public bool Decrypt(string passwordencrypt, string password)
        {
            byte[] data = Convert.FromBase64String(passwordencrypt);
            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            string encrypt = Encoding.UTF8.GetString(result);

            return password == encrypt ? true : false;
        }

    }
}