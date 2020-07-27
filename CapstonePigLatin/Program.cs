using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CapstonePigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = "y";
            while (cont == "y")
            {
                

                Console.WriteLine("Please enter a sentence that you would like translated:");
                string input = Console.ReadLine().ToLower();

               
                    string[] inputSentence = WordSplit(input);
                    string output = SentenceStitch(inputSentence);
                    Console.WriteLine(output);

                
                do
                {
                    Console.WriteLine("Would you like to translate another word y/n?");
                    cont = Console.ReadLine();

                    if (cont == "y")
                    {
                        break;
                    }
                    else if (cont == "n")
                    {
                        Console.WriteLine("Goodbye");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Please make a valid entry");
                    }
                } while (cont != "y" || cont != "n");


            }





        }

        public static string[] WordSplit(string sentence)
        {
            char[] spaces = "   ".ToCharArray();
            

           
            string[] wordArray = sentence.Split(spaces);

            return wordArray;

        }

        public static string PigLatinTranslate(string input)
        {
            char[] vowels = "aeiou".ToCharArray();
            int vowelposition = input.IndexOfAny(vowels);
            if (input[0] == 'a' || input[0] == 'e' || input[0] == 'i' || input[0] == 'o' || input[0] == 'u')
            {
                string startsWithVowel = input + "way";
                return startsWithVowel;
            }

            else
            {


                string wordparttwo = input.Substring(vowelposition);
                string wordpartone = input.Substring(0, vowelposition);
                string pigword = wordparttwo + wordpartone + "ay";
                return pigword;

            }
        }

        public static string SentenceStitch(string[] pigsentence)
        {
            string complete = "";
            foreach (string word in pigsentence)
            {
                 complete = complete + " " + PigLatinTranslate( word);
            }
            return complete;
        }







    }






}


