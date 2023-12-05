using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

Main();

void Main() {
int SecretNumber = RandomNumber();
int Guesses = 1;
int GuessMax = 0;
SetDifficulty(SecretNumber, Guesses, GuessMax);
}

static int RandomNumber() {
    Random r = new Random();
    int genRand= r.Next(1,100);
   return genRand;
}

void SetDifficulty(int SecretNumber, int Guesses, int GuessMax) {
    Console.WriteLine("-----------------------------");
 Console.WriteLine("Select Your Difficulty");
    Console.WriteLine("-----------------------------");
    List<Difficulty> Difficulties = GetDifficulties();
    foreach (Difficulty difficulty in Difficulties)
    {
        if(difficulty.NumGuesses != int.MaxValue){
        Console.WriteLine($"{difficulty.Index}. {difficulty.Name} ({difficulty.NumGuesses} guesses)");
        } else {
           Console.WriteLine($"{difficulty.Index}. {difficulty.Name} (Infinite guesses)"); 
        }
    }
    string UserDifficulty = Console.ReadLine();
    if (int.TryParse(UserDifficulty, out int setting)){
        Difficulty difficulty = Difficulties.First(d => d.Index == setting);
        GuessMax = difficulty.NumGuesses;
        GuessNumber(SecretNumber, Guesses, GuessMax, difficulty.NumGuesses);
    }
}

void GuessNumber(int SecretNumber, int Guesses, int GuessMax, int GuessesSetting) {
    Console.WriteLine("");
Console.WriteLine("-----------------------------");
 Console.WriteLine("Guess the super secret number");
    Console.WriteLine("-----------------------------");
    if(GuessesSetting != int.MaxValue){
    Console.WriteLine($"Guesses left ({GuessMax})");
    Console.WriteLine("-----------------------------");
    }
    Console.Write($"Guess #{Guesses} >");
    string UserInput = Console.ReadLine();
    
    if(int.TryParse(UserInput, out int num))
    {
        if(num == SecretNumber){
            Console.WriteLine("You guessed right! How did you know?!");
        } else if(num != SecretNumber && Guesses < GuessesSetting){
            if(num > SecretNumber) {
            Console.WriteLine("You guessed too high. Try again.");
            Guesses++;
            GuessMax--;
            GuessNumber(SecretNumber, Guesses, GuessMax, GuessesSetting);
            } else if(num < SecretNumber) {
Console.WriteLine("You guessed too low. Try again.");
            Guesses++;
            GuessMax--;
            GuessNumber(SecretNumber, Guesses, GuessMax, GuessesSetting);
            }
        } else {
            Console.WriteLine("You guessed wrong. Out of guesses");
        }
    } else {
        Console.WriteLine("Not a number");
        GuessNumber(SecretNumber, Guesses, GuessMax, GuessesSetting);   
    }
}

List<Difficulty> GetDifficulties()
{
    List<Difficulty> allDifficulties = new List<Difficulty>() {
        new Difficulty() {
            Index = 1,
            Name = "Easy",
            NumGuesses = 8
        },
        new Difficulty() {
            Index = 2,
            Name = "Medium",
            NumGuesses = 6
        },
        new Difficulty() {
            Index = 3,
            Name = "Hard",
            NumGuesses = 4
        },
        new Difficulty() {
            Index = 4,
            Name = "Cheater",
            NumGuesses = int.MaxValue
        }
    };
    return allDifficulties;
    }
   
public class Difficulty
{
    public int Index { get; set;}
    public string Name { get; set; }
    public int NumGuesses { get; set; }
}



