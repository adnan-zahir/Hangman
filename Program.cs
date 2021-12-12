namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman game = new();
            game.Start();
        }
    }
    class Hangman
    {
        Random random = new();
        string[] possibleWords = new string[] {
            "kucing",
            "anjing",
            "monyet",
            "baboon"
        };
        string? wordToGuess;
        List<char> guessedWord = new List<char>();
        char? guessedChar;
        char fixedChar;
        bool playAgain = true;
        int health = 0;

        public void Start()
        {
            Console.Clear();
            int index = random.Next(possibleWords.Length);
            wordToGuess = possibleWords[index];
            health = 8;
            guessedWord.Clear();
            foreach (char c in wordToGuess) guessedWord.Add('_');

            string allowedChar = "abcdefghijklmnopqrstuvwxyz";

            while (true)
            {
                Draw();
                Display();

                Console.Clear();

                // Check if the char is null
                if (guessedChar == null) continue;
                else fixedChar = (char)guessedChar;

                // Check if the char is valid
                if (!allowedChar.Contains(fixedChar)) continue;

                // Check if the guess is correct
                if (wordToGuess.Contains(fixedChar))
                {
                    Console.WriteLine("Good guess!");
                    UpdateGuess(fixedChar, wordToGuess);
                }
                else
                {
                    health--;
                    Console.WriteLine("Oops, try again!");
                }

                if (CheckWin()) break;

                if (CheckHealth()) break;
            }

            CheckReplay();
        }
        private void Display()
        {
            // Display guessed word and health
            Console.Write("Word :");
            foreach (char c in guessedWord) Console.Write(c);
            Console.WriteLine();
            Console.WriteLine($"Health : {health}");
            // Read char input
            Console.Write("Guess one character : ");
            guessedChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        private bool CheckWin()
        {
            // Check if all correct
            if (new string(guessedWord.ToArray()) == wordToGuess)
            {
                Console.Clear();
                Draw();
                Console.WriteLine("You win!");
                Console.WriteLine($"The word is : {wordToGuess}");
                return true;
            }
            return false;
        }
        private bool CheckHealth()
        {
            if (health <= 0)
            {
                Draw();
                Console.WriteLine("You run out of health! Game over!");
                return true;
            }
            return false;
        }
        private void UpdateGuess(char fixedChar, string wordToGuess)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (fixedChar == wordToGuess[i])
                {
                    guessedWord[i] = wordToGuess[i];
                }
            }
        }
        private void CheckReplay()
        {
            while (playAgain)
            {
                if (IsReplay())
                {
                    Start();
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        private bool IsReplay()
        {
            Console.WriteLine("Do you want to play again? [y/N]");
            string? answer = Console.ReadLine();
            if (answer != null && answer.ToUpper() == "Y")
            {
                return true;
            }
            return false;
        }
        private void Draw()
        {
            switch (health)
            {
                case 8:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 7:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 6:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 5:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 4:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |          /|\\");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 3:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |          /|\\");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 2:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |          /|\\");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          / \\");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                case 1:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (0)");
                    Console.WriteLine(" |          /|\\");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          / \\");
                    Console.WriteLine(" |         /");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
                default:
                    Console.WriteLine(" |------------");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          (X)");
                    Console.WriteLine(" |          /|\\");
                    Console.WriteLine(" |           |");
                    Console.WriteLine(" |          / \\");
                    Console.WriteLine(" |         /   \\");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|______________");
                    break;
            }
        }
    }
}
