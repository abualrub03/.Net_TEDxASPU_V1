using System.Security.Cryptography;
using System.Text;

public static class AesEncryption
{

    public static byte[] getEncryptor(string strKey , byte[] textByte,string strSalt)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes(strKey);
        byte[] saltByte = null;
        if (string.IsNullOrEmpty(strSalt))
        {
            saltByte = new byte[] { 0x11, 0x33, 0x44, 0x22, 0x02, 0x92, 0x18, 0x17, 0x62, 0x52, 0x42, 0x13, 0x93, 0x94, 0x96, 0x97 };
        }
        else
        {
            saltByte = Encoding.UTF8.GetBytes(strSalt);
        }
        byte[] encryptedFile = null;
        try
        {
            using(var memory = new MemoryStream())
            {
                using(var aes = new AesManaged()) {                                
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(keyByte,saltByte,2000);
                    aes.Key=key.GetBytes(aes.KeySize / 8 );
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    using (var ICrypto = new CryptoStream(memory, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        ICrypto.Write(textByte, 0, textByte.Length);
                        ICrypto.FlushFinalBlock();
                        ICrypto.Close();
                    }                   
                }
                encryptedFile = memory.ToArray();
                memory.Close();
            }
            return encryptedFile;

        }catch 
        {
            return null;
        }


    }


    public static byte[] getDecryptor(string strKey, byte[] textByte, string strSalt)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes(strKey);
        byte[] saltByte = null;
        if (string.IsNullOrEmpty(strSalt))
        {
            saltByte = new byte[] { 0x11, 0x33, 0x44, 0x22, 0x02, 0x92, 0x18, 0x17, 0x62, 0x52, 0x42, 0x13, 0x93, 0x94, 0x96, 0x97 };
        }
        else
        {
            saltByte = Encoding.UTF8.GetBytes(strSalt);
        }
        byte[] encryptedFile = null;
        try
        {
            using (var memory = new MemoryStream())
            {
                using (var aes = new AesManaged())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(keyByte, saltByte, 2000);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    using (var ICrypto = new CryptoStream(memory, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        ICrypto.Write(textByte, 0, textByte.Length);
                        ICrypto.FlushFinalBlock();
                        ICrypto.Close();
                    }
                }
                encryptedFile = memory.ToArray();
                memory.Close();
            }
            return encryptedFile;

        }
        catch
        {
            return null;
        }


    }


}

