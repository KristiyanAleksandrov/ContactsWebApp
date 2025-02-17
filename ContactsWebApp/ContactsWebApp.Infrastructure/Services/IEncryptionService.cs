namespace ContactsWebApp.Infrastructure.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string input);
        string Decrypt(string encryptedInput);
    }
}