using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {   
        const int limitGame = 30;
        const int bonusAdvance = 3;
        const int penalty = 2;

        PlayGame(limitGame, bonusAdvance, penalty);

    }

    static void PlayGame(int limitGame, int bonusAdvance, int penalty)
    {   
        GameIntro();

        while(true)
        {
            int p1Position = 0;
            int pcPosition = 0;

            while(true)
            {
                p1Position = Player1(p1Position, limitGame, bonusAdvance, penalty);

                if(p1Position >= limitGame)
                    break;

                pcPosition = Pc(pcPosition, limitGame, bonusAdvance, penalty);
                
                if(pcPosition >= limitGame)
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

    static void TurnPlayer(string playerName)
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine($"{playerName} TURN");
        Console.WriteLine("============================");   
    }
    static int Player1(int p1Position, int limitGame, int bonusAdvance, int penalty)
    {
      do
        {
        
            Console.Clear();
            TurnPlayer("Player1");
            Console.WriteLine("Press ENTER to roll the dice...");
            Console.ReadLine();

            int resultDiceP1 = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine($"Your dice number was: {resultDiceP1}.");
            Console.WriteLine("----------------------------");
                
            p1Position += resultDiceP1;

            Console.WriteLine($"Now you are: {p1Position} of {limitGame}.");
            Console.WriteLine("----------------------------");
            
            if(p1Position == 5 ||p1Position == 10 || p1Position == 15 || p1Position == 25)
            {   
                Console.WriteLine($"EVENT: Advance {bonusAdvance} spaces!.");
                
                p1Position += bonusAdvance;
                Console.WriteLine($"Now you are: {p1Position} of {limitGame}.");
                Console.WriteLine("----------------------------");
            }
            else if(p1Position == 7 || p1Position == 13 || p1Position == 20)
            {
                Console.WriteLine($"EVENT: Go back {penalty} spaces!.");
                
                p1Position -= penalty;
                Console.WriteLine($"Now you are: {p1Position} of {limitGame}.");
                Console.WriteLine("----------------------------");
            }

            if(p1Position >= limitGame)
            {
                Console.WriteLine("CONGRATS!!! YOU WIN THE GAME!!");
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadLine();

                break;
            }

            if(resultDiceP1 == 6)
            {
                Console.WriteLine("WIN ANOTHER ROLL DICE!!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Press ENTER to roll again...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                
                break;

            }


        }while(true);

        return p1Position;
    }

    static int Pc(int pcPosition, int limitGame, int bonusAdvance, int penalty)
    {
        do
        {
            TurnPlayer("PC");

            int resultDicePc = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine($"The number drawn was: {resultDicePc}");
            Console.WriteLine("----------------------------");
                
            pcPosition += resultDicePc;
            
            Console.WriteLine($"PC stay in: {pcPosition} of {limitGame}.");
            Console.WriteLine("----------------------------");

            if(pcPosition == 5 ||pcPosition == 10 || pcPosition == 15 || pcPosition == 25)
            {   
                Console.WriteLine($"EVENT: Advance {bonusAdvance} spaces!.");
                pcPosition += bonusAdvance;
                Console.WriteLine($"PC stay in: {pcPosition} of {limitGame}.");
            }
            else if(pcPosition == 7 || pcPosition == 13 || pcPosition == 20)
            {
                Console.WriteLine($"EVENT: Go back {penalty} spaces!..");
                pcPosition -= penalty;
                Console.WriteLine($"PC stay in: {pcPosition} of {limitGame}.");
            }

            if(pcPosition >= limitGame)
            {
                Console.WriteLine("CONGRATS!!! PC WIN THE GAME!!");
                Console.ReadKey();
                break;
            }

            if(resultDicePc == 6)
            {
                Console.WriteLine("WIN ANOTHER ROLL DICE!!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Press ENTER to roll again...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                
                break;

            }

        }while(true);

        return pcPosition;
    }
    
    static bool PlayAgain()
    {
        Console.WriteLine("Do you want play again? Press: (Y/N)");
        string? userChoise = Console.ReadLine().ToUpper();

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

}
