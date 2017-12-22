using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EmprestaGame.API.Criptography
{
    public static class Cripto
    {
        public static String GeraToken(string usuario, string enderecoIP)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(usuario + enderecoIP + DateTime.Now.ToString());

            SHA1 sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            return HexStringFromBytes(hashBytes);
        }

        public static String GeraChaveSystemManager(string sistema, string chave)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(sistema + chave);
            SHA1 sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            return HexStringFromBytes(hashBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                string hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}