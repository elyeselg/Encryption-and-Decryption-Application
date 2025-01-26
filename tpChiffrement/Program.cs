using System.Security.Cryptography;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the encryption and decryption application!");

        while (true)
        {
            // Displaying options to the user
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Encrypt a message");
            Console.WriteLine("2. Decrypt a message");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EncryptMessage(); // Call the function to encrypt a message
                    break;
                case "2":
                    DecryptMessage(); // Call the function to decrypt a message
                    break;
                case "3":
                    Environment.Exit(0); // Exit the application
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again."); // Handle invalid inputs
                    break;
            }
        }
    }

    // Function to encrypt a message
    static void EncryptMessage()
    {
        Console.Write("Enter the message to encrypt: ");
        string message = Console.ReadLine();

        using (Aes aesAlg = Aes.Create())
        {
            // Generate a new encryption key and initialization vector (IV)
            aesAlg.GenerateKey();
            aesAlg.GenerateIV();

            byte[] key = aesAlg.Key;
            byte[] iv = aesAlg.IV;

            // Encrypt the message
            byte[] encryptedData = EncryptStringToBytes_Aes(message, key, iv);

            // Display the encrypted message, key, and IV (all base64-encoded)
            Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Key: " + Convert.ToBase64String(key));
            Console.WriteLine("IV: " + Convert.ToBase64String(iv));
        }
    }

    // Function to decrypt a message
    static void DecryptMessage()
    {
        Console.Write("Enter the encrypted message: ");
        string encryptedMessage = Console.ReadLine();
        Console.Write("Enter the key: ");
        string keyInput = Console.ReadLine();
        Console.Write("Enter the IV: ");
        string ivInput = Console.ReadLine();

        // Convert the base64-encoded inputs to byte arrays
        byte[] key = Convert.FromBase64String(keyInput);
        byte[] iv = Convert.FromBase64String(ivInput);
        byte[] encryptedData = Convert.FromBase64String(encryptedMessage);

        // Decrypt the message
        string decryptedMessage = DecryptStringFromBytes_Aes(encryptedData, key, iv);

        // Display the decrypted message
        Console.WriteLine("Decrypted message: " + decryptedMessage);
    }

    // Helper function to encrypt a string to a byte array using AES encryption
    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
    {
        byte[] encrypted;
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key; // Set the encryption key
            aesAlg.IV = iv;   // Set the initialization vector (IV)

            // Create an encryptor to perform the encryption
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create a memory stream to hold the encrypted data
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Create a CryptoStream to apply the encryption
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Use a StreamWriter to write the plaintext into the CryptoStream
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText); // Write the plaintext message
                    }
                }
                encrypted = msEncrypt.ToArray(); // Get the encrypted data from the memory stream
            }
        }
        return encrypted; // Return the encrypted byte array
    }

    // Helper function to decrypt a byte array back to a string using AES decryption
    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
    {
        string plaintext = null;
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key; // Set the decryption key
            aesAlg.IV = iv;   // Set the initialization vector (IV)

            // Create a decryptor to perform the decryption
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create a memory stream with the encrypted data
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                // Create a CryptoStream to apply the decryption
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // Use a StreamReader to read the decrypted data from the CryptoStream
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd(); // Read the decrypted message
                    }
                }
            }
        }
        return plaintext; // Return the decrypted string
    }
}
