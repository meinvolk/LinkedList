using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LinkedListProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Provide the Text input filename and desired output filename. ( wap.txt ) is the default input file. Or hit ENTER to use default values.");
            Console.Write("CharacterCounterProgram.exe ");

            //String manipulation to get input and output string values.
            string userInput = Console.ReadLine();
            int posA = userInput.IndexOf(" ");
            int lastPostion = userInput.Length - 1;

            //Get or set the value for the input text file to be read.
            string input = "wap.txt";
            string output = "Default.txt";
            try
            {
                input = userInput.Substring(0, posA);
                output = userInput.Substring(posA).Trim(' ');
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Input was poorly formed default values have been set.");
            }

            //Get path to Bin
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string body = File.ReadAllText(path + input);

            //Initialize CharFreq Object as LinkedList.
            LinkedList<CharFreq> charFreqList = new LinkedList<CharFreq>();

            char ch;
            StreamReader reader;
            reader = new StreamReader(path + input);

            do
            {
                ch = (char)reader.Read();
                
                CharFreq newCharItem = new CharFreq(ch);

                //Find instance of the new character object against existing characters in the liked list with Find Method.
                LinkedListNode<CharFreq> ListNode = charFreqList.Find(newCharItem);

                //If Find method found a match then increment the node.
                if (ListNode != null) ListNode.Value.Increment();

                //If nothing was found in Linked list then create new node.
                else charFreqList.AddLast(newCharItem);

            } while (!reader.EndOfStream);
            reader.Close();

            // Write the CharFreq LinkList data to a new file.
            using (StreamWriter outputFile = new StreamWriter(path + @"\" + output))
            {
                foreach (CharFreq character in charFreqList)
                {
                    if (character != null)
                    {
                        outputFile.WriteLine(character.ToString());

                        Console.WriteLine(character.ToString());
                    }
                }
            }

            Console.WriteLine("Press Enter to Exit the Application...");
            Console.Read();
        }
    }
}
