namespace WordDescrambler
{
    class Program
    {
        static bool InputValidation(string wordInput)
        {
            return !string.IsNullOrWhiteSpace(wordInput) && wordInput.All(char.IsLetter);
        }


        static string SortChar(string words)
        {
            char[] sorted = words.ToLower().OrderBy(c => c).ToArray();
            return new string(sorted);
        }
        static List<string> DictionaryList(string wordInput)
        {
            const string path = "words_alpha.txt";
            List<string> wordList= new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string words;    
                    string temp = SortChar(wordInput.ToLower());
         
                    while ((words = reader.ReadLine()) != null)   
                    {
                        if (words.Length <= temp.Length)
                        {
                            string tempWords = SortChar(words.ToLower());
                            if (temp.Contains(tempWords)){
                                wordList.Add(words);
                            }
                        }
                    }         
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file " + ex.Message);
            };      

            return wordList;      
        }

        static void Main()
        {
            string wordInput;
            do {
                Console.Write("Enter a word: ");
                wordInput = Console.ReadLine();

                if (!InputValidation(wordInput)) {
                    Console.WriteLine("Word must contains letters only and no space. Please try again.");
                }
            }
            while (!InputValidation(wordInput));

            List<string> wordDescrambler = DictionaryList(wordInput);
            Console.WriteLine("Matching Words: ");
            foreach (string words in wordDescrambler)
            {
                Console.WriteLine(words);
            }
        }
    }
}