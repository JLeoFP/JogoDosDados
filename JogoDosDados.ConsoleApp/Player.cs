using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

static class Player
{
    public static int p1Position = 0;
    private const int limitGame = 30;
    private const int bonusAdvance = 3;
    private const int penalty = 2;
   
    public static void Play()
    {
      do
        {
        
            Console.Clear();
            Player.TurnPlayer();
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

        
    }

    public static bool Win()
    {
        return p1Position >= limitGame;
    }
     private static void TurnPlayer()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("PLAYER 1 TURN");
        Console.WriteLine("============================");   
    }
    
}
