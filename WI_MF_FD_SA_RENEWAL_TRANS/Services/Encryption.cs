using System.Security.Cryptography;
using System.Text;

namespace WI_MF_FD_SA_GEN_DOCS.Services
{
    public class Encryption
    {
        public Encryption()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string EncryptText(string inputValue, string inputsalt)
        {

            string salt = "12S3F45GT56H6J666J666K6" + inputsalt;

            byte[] utfData = UTF8Encoding.UTF8.GetBytes(inputValue);

            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            string encryptedString = string.Empty;

            using (AesManaged aes = new AesManaged())
            {

                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(salt, saltBytes);

                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;

                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfc.GetBytes(aes.KeySize / 8);

                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                using (ICryptoTransform encryptTransform = aes.CreateEncryptor())
                {

                    using (MemoryStream encryptedStream = new MemoryStream())
                    {

                        using (CryptoStream encryptor =

                        new CryptoStream(encryptedStream, encryptTransform, CryptoStreamMode.Write))
                        {

                            encryptor.Write(utfData, 0, utfData.Length);

                            encryptor.Flush();

                            encryptor.Close();

                            byte[] encryptBytes = encryptedStream.ToArray();

                            encryptedString = Convert.ToBase64String(encryptBytes);

                        }

                    }

                }

            }

            return encryptedString;

        }
    }
}
