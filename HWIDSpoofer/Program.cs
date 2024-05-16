using System;

namespace HWIDSpoofer
{
    class Program
    {
        public static string textLogo =
             @"                                                                    " + Environment.NewLine +
             @"                          )       (              )                  " + Environment.NewLine +
             @"            (          ( /(       )\ )    (   ( /(  (      (   (    " + Environment.NewLine +
             @" `  )   (   )\ )   (   )\())  (  (()/(   ))\  )\()) )(    ))\  )(   " + Environment.NewLine +
             @" /(/(   )\ (()/(   )\ ((_)\   )\  /(_)) /((_)((_)\ (()\  /((_)(()\  " + Environment.NewLine +
             @"((_)_\ ((_) )(_)) ((_)| |(_) ((_)(_) _|(_))( | |(_) ((_)(_))   ((_) " + Environment.NewLine +
             @" /(/(   )\ (()/(   )\ ((_)\   )\  /(_)) /((_)((_)\ (()\  /((_)(()\  " + Environment.NewLine +
             @"((_)_\ ((_) )(_)) ((_)| |(_) ((_)(_) _|(_))( | |(_) ((_)(_))   ((_) " + Environment.NewLine +
             @"| '_ \)(_-<| || |/ _| | ' \ / _ \ |  _|| || || ' \ | '_|/ -_) | '_| " + Environment.NewLine +
             @"| .__/ /__/ \_, |\__| |_||_|\___/ |_|   \_,_||_||_||_|  \___| |_|   " + Environment.NewLine +
             @"|_|         |__/                                                    " + Environment.NewLine;

        static void Main(string[] args)
        {
        begin:
            Console.Title = "spoofer by @psychofuhrer";
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine(textLogo);
            Console.WriteLine("   __ Функции ________________________________  ");
            Console.WriteLine("  | [!hwid] Подмена HWID                      | ");
            Console.WriteLine("  | [!guid] Подмена Guid                      | ");
            Console.WriteLine("  | [!pcName] Подмена имени компьютера        | ");
            Console.WriteLine("  | [!productId] Подмена ключа                | ");
            Console.WriteLine("  |___________________________________________| ");

            string input = Console.ReadLine();
            if(input == "!hwid")
            {
                Console.Clear();
                Console.WriteLine(textLogo);
                if (Spoofer.HWID.Spoof())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Spoofer.HWID.Log.ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Spoofer.HWID.Log.ToString());
                }
                Console.ReadLine();
                goto begin;
            }
            else if (input == "!guid")
            {
                Console.Clear();
                Console.WriteLine(textLogo);
                if (Spoofer.PCGuid.Spoof())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Spoofer.PCGuid.Log.ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Spoofer.PCGuid.Log.ToString());
                }
                Console.ReadLine();
                goto begin;
            }
            else if (input == "!pcName")
            {
                Console.Clear();
                Console.WriteLine(textLogo);
                if (Spoofer.PCName.Spoof())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Spoofer.PCName.Log.ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Spoofer.PCName.Log.ToString());
                }
                Console.ReadLine();
                goto begin;
            }
            else if (input == "!productId")
            {
                Console.Clear();
                Console.WriteLine(textLogo);
                if (Spoofer.ProductId.Spoof())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Spoofer.ProductId.Log.ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Spoofer.ProductId.Log.ToString());
                }
                Console.ReadLine();
                goto begin;
            }
            else
            {
                goto begin;
            }
        }
    }
}
