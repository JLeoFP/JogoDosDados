using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
class Program
{
    static void Main(string[] args)
    {   
        GameIntro();
        while(true)
        {
            Restard();
            while(true)
            {
                Player.Play();
                if(Player.Win())
                    break;

                Computador.PcPlay();
                if(Computador.Win())
                    break;
            }

            if(!PlayAgain())
                break;
        }

    }
    static void GameIntro()
    {
        Console.WriteLine("============================");
        Console.WriteLine("WELCOME TO THE DICE GAME");
        Console.WriteLine("============================");
        Console.WriteLine("First to reach 30 wins!");
        Console.WriteLine("Special squares:");
        Console.WriteLine("  5, 10, 15, 25 → Advance 3 spaces");
        Console.WriteLine("  7, 13, 20 → Go back 2 spaces");
        Console.WriteLine("  Roll a 6 → Extra turn!");
        Console.WriteLine("============================");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();

    }
    static bool PlayAgain()
    {
        Console.WriteLine("Do you want play again? Press: (Y/N)");
        string? userChoise = Console.ReadLine()!.ToUpper();

        if(userChoise != "Y")
        {   
            Console.WriteLine("============================");
            Console.WriteLine("Thanks for playing.");
            Console.WriteLine("See you later!!");
            Console.WriteLine("============================");
            Console.ReadKey();
            return false;
        }
        return true;
 
    }
    static void Restard()
    {
        Player.p1Position = 0;
        Computador.pcPosition = 0;
    }
}
