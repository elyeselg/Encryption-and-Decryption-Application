## Project Overview

This is a simple encryption and decryption application built in C#. The application allows users to securely encrypt messages and decrypt them using the AES (Advanced Encryption Standard) algorithm. The AES algorithm is a symmetric encryption method, ensuring both security and efficiency.
Features

    Encrypt a message: Convert a plain text message into an encrypted format.
    Decrypt a message: Revert the encrypted message back to its original form using the provided key and initialization vector (IV).
    User-friendly console interface.
    Automatically generates a unique key and IV for each encryption session.

## Requirements

    .NET Framework or .NET Core installed on your system.
    Any compatible IDE (e.g., Visual Studio) or a command-line interface for running the application.

## How to Use

    Run the application:
    Open a terminal or your IDE and run the program.

    Select an option:
    After launching, you’ll see a menu with the following options:
        1. Encrypt a message: To encrypt a text message.
        2. Decrypt a message: To decrypt an encrypted message.
        3. Exit: To close the application.

    Encryption Process:
        Select option 1.
        Enter the message you want to encrypt.
        The application will generate:
            Encrypted message (in Base64 format).
            Encryption key (Base64 encoded).
            Initialization vector (IV, also Base64 encoded).
        Save the key and IV as they are required for decryption.

    Decryption Process:
        Select option 2.
        Enter:
            The encrypted message.
            The encryption key.
            The IV.
        The application will display the original decrypted message.
        

## Code Structure

    Main Method: Displays the menu and manages user input.
    EncryptMessage(): Handles message encryption and outputs the encrypted data, key, and IV.
    DecryptMessage(): Handles message decryption using the provided key and IV.
    EncryptStringToBytes_Aes(): Core function for AES encryption.
    DecryptStringFromBytes_Aes(): Core function for AES decryption.
    

## Security Notes

    Keep your encryption key and IV private: The security of the AES algorithm relies on the confidentiality of these values.
    Each encryption generates a unique key and IV, ensuring that the same message does not produce identical encrypted outputs.

## Possible Enhancements

    Add support for saving and loading keys/IVs from files.
    Implement password-based key derivation for additional security.
    Create a GUI (Graphical User Interface) for better user experience.

## License

This project is released under the MIT License. Feel free to use, modify, and distribute it.
