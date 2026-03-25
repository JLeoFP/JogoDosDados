using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

static class Computador
{
    public static int pcPosition = 0;
    private const int limitGame = 30;
    private const int bonusAdvance = 3;
    private const int penalty = 2;

    public static bool Win()
    {
        return pcPosition >= limitGame;
    }
    public static void PcPlay()
    {
        do
        {
            Computador.TurnPlayer();

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

    } 

   private static void TurnPlayer()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("PC TURN");
        Console.WriteLine("============================");   
    }
}
