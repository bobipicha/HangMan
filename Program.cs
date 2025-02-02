
class Program
{
    static void Main()
    {
        string word;
       Console.WriteLine("Welcome to HangMan! (fruit edition)");
        do
        {
            word = RandomWord();
            HangMan(word,Difficulty());
            Console.WriteLine("Would you like to play again? (y/n)");
        }
        while ((Console.ReadLine().ToLower() == "y"));
        Console.WriteLine("Thank you for playing!");


    }
    static string RandomWord(string word="")
    {
        string[] words = { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon", "mango", "nectarine", "orange", "papaya", "quince", "raspberry", "strawberry", "tangerine", "watermelon" };
        Random random = new Random();
        int index = random.Next(0,words.Length);
        word = words[index];
        return word;
    }
    static void HangMan(string word, string difficulty)
    {
        int lives = livesMethod(difficulty);
        int currentlives = lives; 
        bool win = false;
        List<char> GuessedLetters = new List<char>();
        while (currentlives > 0 && !win)
        {
            foreach (char letter in word)
            {
                if (GuessedLetters.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write("_");
                }
            }
            
            Console.WriteLine($" {currentlives} Lives remaining");
            Console.WriteLine("Please type a letter:");
            char guess = char.Parse(Console.ReadLine());
            Console.Clear();
            if (word.Contains(guess) && !GuessedLetters.Contains(guess))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                currentlives--;

            }
            GuessedLetters.Add(guess);
            bool wordComplete = true;
            foreach (char letter in word)
            {
                if (!GuessedLetters.Contains(letter))
                {
                    wordComplete = false;
                }
            }
            win = wordComplete;
        }
       if(win)
        {
            Console.WriteLine("Congratulations! You won!");
        }
        else
        {
            Console.WriteLine("You lost! The word was: " + word);
        }
    }
    static string Difficulty(string difficulty = "")
    {
        while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard")
        {
            Console.WriteLine($"Please select the difficulty:");
            Console.Write("Easy (9 lives) Medium (7 lives) or Hard (5 lives)");
            Console.WriteLine();
            difficulty = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine($"You have selected {difficulty} difficulty.");
        }
        return difficulty;
    }
    static int livesMethod(string difficulty)
    {
        int lives;
        if (difficulty == "easy")
        {
            lives = 9;
        }
        else if (difficulty == "medium")
        {
            lives = 7;
        }
        else
        {
            lives = 5;
        }

        return lives;
    }
     
}