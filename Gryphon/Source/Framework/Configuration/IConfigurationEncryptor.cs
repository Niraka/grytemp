namespace Gryphon.Framework.Configuration
{
    public interface IConfigurationEncryptor
    {
        byte[] Encrypt(string sValue);

        string Decrypt(byte[] value);
    }
}
