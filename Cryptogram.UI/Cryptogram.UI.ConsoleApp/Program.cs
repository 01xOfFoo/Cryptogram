using Cryptogram.Ciphers.DoubleTranspositionCipher;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;
using Cryptogram.UI.ConsoleApp.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptogram.UI.ConsoleApp
{
    public class Program
    {
        private static IKeywordedCipher cipher;
        private static Keywords keywords;
        private static TaskType taskType;
        private static string givenText;

        public static void Main(string[] args)
        {
            try
            {
                deencryptText(args);
            }
            catch (Exception e)
            {
                PrintUsageExplanation(e);
            }
        }

        private static void PrintUsageExplanation(Exception e)
        {
            string outText = string.Format("\nError: {0}\n\n", e.Message);
            outText += "ConsoleApp.exe [task] [text] [keywords1,keywords2,...]\n\n";
            outText += "task:\t\tcrypt, decrypt\n";
            outText += "text:\t\ttext which should be en- or decrypted\n";
            outText += "keywords:\tcomma separated pairs\n";

            System.Console.WriteLine(outText);
        }

        private static void deencryptText(string[] args)
        {
            if (args.Length < 3)
                throw new NotEnoughArgumentsException();

            ExtractArguments(args);

            string processedText = HandleArguments();
            PrintResult(processedText);
        }

        private static void ExtractArguments(string[] args)
        {
            keywords = ExtractKeywordsOfArguments(args);
            taskType = ExtractTaskTypeOfArguments(args);
            givenText = ExtractProcessingTextOfArguments(args);
        }

        private static Keywords ExtractKeywordsOfArguments(string[] args)
        {
            return new CommaArgumentToKeywordsConverter().Convert(args[2]);
        }

        private static string ExtractProcessingTextOfArguments(string[] args)
        {
            return args[1];
        }

        private static TaskType ExtractTaskTypeOfArguments(string[] args)
        {
            return ParseTaskTypeOfArgument(args[0]);
        }

        private static TaskType ParseTaskTypeOfArgument(string argument)
        {
            return (TaskType)Enum.Parse(typeof(TaskType), argument);
        }

        private static string HandleArguments()
        {
            IKeywordedCipher cipher = new DoubleTranspositionCipher();

            switch (taskType)
            {
                case TaskType.Encryption:
                    return CryptText();
                case TaskType.Decryption:
                    return DecryptText();
                default:
                    throw new InvalidOperationException();
            }
        }

        private static string DecryptText()
        {
            cipher.SetKeywords(keywords);
            return cipher.Decrypt(givenText);
        }

        private static string CryptText()
        {
            cipher.SetKeywords(keywords);
            return cipher.Encrypt(givenText);
        }

        private static void PrintResult(string text)
        {
            string outText = string.Format("{0} successfull: {0}",
                                           new object[] { taskType.ToString(), text });
            System.Console.WriteLine(text);
        }
    }
}
