using System;

namespace CaesarCipher
{
  class Program
  {
    static char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                  'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

    static void Main(string[] args)
    {
      Console.Write("Enter your secret message: ");
      string input = Console.ReadLine();

      char[] secretMessage = input.ToCharArray();

      char[] encryptedMessage = Encrypt(secretMessage, 3);

      string encodedString = String.Join(" ", encryptedMessage);

      Console.WriteLine($"Your encoded message is {encodedString}");

      char[] decryptedMessage = Decrypt(encryptedMessage, 3);

      string decodedString = String.Join("", decryptedMessage);

      Console.WriteLine($"Your decoded message is {decodedString}");
    }

    static char[] Encrypt(char[] message, int key)
    {
      char[] encryptedMessage = new char[message.Length];

      for (int i = 0; i < message.Length; i++)
      {
        char letter = char.ToLower(message[i]);
        if (!char.IsLetter(letter))
        {
          encryptedMessage[i] = letter;
          continue;
        }
        int letterPosition = Array.IndexOf(alphabet, letter);
        int newLetterPosition = (letterPosition + key) % alphabet.Length;
        char letterEncoded = alphabet[newLetterPosition];
        encryptedMessage[i] = letterEncoded;
      }

      return encryptedMessage;
    }

    static char[] Decrypt(char[] message, int key)
    {
      char[] decryptedMessage = new char[message.Length];

      for (int i = 0; i < message.Length; i++)
      {
        char letter = char.ToLower(message[i]);
        if (!char.IsLetter(letter))
        {
          decryptedMessage[i] = letter;
          continue;
        }
        int letterPosition = Array.IndexOf(alphabet, letter);
        int newLetterPosition = (letterPosition - key + alphabet.Length) % alphabet.Length;
        char letterDecoded = alphabet[newLetterPosition];
        decryptedMessage[i] = letterDecoded;
      }

      return decryptedMessage;
    }
  }
}