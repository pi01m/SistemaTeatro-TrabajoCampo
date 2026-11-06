using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Servicio
{
    public class Servicio_Cripto
    {
        public string CalcularHash(string cadena)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(cadena);
                byte[] hashBytes = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public string Encriptar_DNI853(string texto)
        {
            byte[] clave = Encoding.UTF8.GetBytes("1234567890123456");

            using (Aes aes = Aes.Create())
            {
                aes.Key = clave; 
                aes.IV = clave;

                byte[] bytes = Encoding.UTF8.GetBytes(texto);

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] resultado = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Convert.ToBase64String(resultado);
                }
            }
        }
         
        public string Desencriptar_DNI853(string textoEncriptado)
        {
            byte[] clave = Encoding.UTF8.GetBytes("1234567890123456");

            using (Aes aes = Aes.Create())
            {
                aes.Key = clave;
                aes.IV = clave;

                byte[] bytes = Convert.FromBase64String(textoEncriptado);

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] resultado = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Encoding.UTF8.GetString(resultado);
                }
            }
        }
    }
}
