using System;

namespace Rekenmachien
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRepeat = false;
            do
            {
                // Bewerking opvragen
                Console.Clear();
                string bewerking; // moeten buiten do while gedeclareerd worden om hun waarde te behouden
                bool isValidOperator;
                do
                {
                    Console.Clear();
                    Console.Write("Geef een bewerking in: ");
                    bewerking = Console.ReadLine(); //  (+, -, *, /)

                    switch (bewerking)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            isValidOperator = true;
                            break;
                        default:
                            isValidOperator = false;
                            break;
                    }
                } while (!isValidOperator); // kort voor isValidOperator == false
                                            // zolang deze op false staat blijft de loop herhalen

                // Getallen opvragen
                double getal1 = 0, getal2 = 0;
                bool isGetal1Valid, isGetal2Valid;
                switch (bewerking)
                {
                    case "+": // optellen
                    case "-": // aftrekken (ew)
                    case "*": // vermenigvuldigen
                        do
                        {
                            Console.Write("Geef getal 1: ");
                            // tryparse zet isGetalValid op true wanneer de parse lukt
                            isGetal1Valid = double.TryParse(Console.ReadLine(), out getal1);

                            Console.Write("Geef getal 2: ");
                            // tryparse zet isGetalValid op true wanneer de parse lukt
                            isGetal2Valid = double.TryParse(Console.ReadLine(), out getal2);

                        } while (!isGetal1Valid || !isGetal2Valid);
                        break;
                    case "/": // delen (enkel hier de extra voorwaarde voor minstens 1 decimaal getal)
                        do
                        {
                            Console.Write("Geef getal 1: ");
                            // tryparse zet isGetalValid op true wanneer de parse lukt
                            isGetal1Valid = double.TryParse(Console.ReadLine(), out getal1);

                            Console.Write("Geef getal 2: ");
                            // tryparse zet isGetalValid op true wanneer de parse lukt
                            isGetal2Valid = double.TryParse(Console.ReadLine(), out getal2);

                            // check voor minstens 1 decimaal getal
                            if (!getal1.ToString().Contains('.') || !getal1.ToString().Contains(',') ||
                                !getal2.ToString().Contains('.') || !getal2.ToString().Contains('.'))
                            {
                                // als er geen . of , gevonden word zijn er geen decimale getallen
                                isGetal1Valid = isGetal2Valid = false;
                            }
                        } while (!isGetal1Valid || !isGetal2Valid);
                        break;
                }

                //Bewerking uitvoeren
                string output = "";
                switch (bewerking)
                {
                    case "+": // bewerkingen die geen specifieke volgorde hebben
                    case "*":

                        if (bewerking == "*") // vermenigvuldigen
                        {
                            // n2 voor visueel 2 na komma, math.round om effectief af te ronden
                            output = $"Het product van {getal1} en {getal2} is {Math.Round(getal1 * getal2, 2):n2}";
                        }
                        else // geen extra if omdat er maar 2 mogelijkheden zijn
                        {
                            output = $"De som van uw getallen {getal1} en {getal2} is gelijk aan {getal1 + getal2}";
                        }
                        break;
                    case "-": // bewerkingen die wel een specifieke volgorde hebben (groot naar klein)
                    case "/":

                        double groot = getal1, klein = getal2;
                        if (getal2 > getal1)
                        {
                            groot = getal2;
                            klein = getal1;
                        }

                        if (bewerking == "/") // delen
                        {
                            output = $"{groot} gedeeld door {klein} is ";

                            if (klein == 0) // wie deelt door nul is een
                            {
                                output += "niet mogelijk";
                            }
                            else
                            {
                                output += "mogelijk\n" +
                                    $"Het resultaat is: {Math.Round(groot / klein, 2):n2}";
                            }
                        }
                        else
                        {
                            if (groot == klein)
                            {
                                output = $"De getallen zijn beide gelijk aan {groot}";
                            }
                            else
                            {
                                output = $"Grootste getal: {groot}\n" +
                                    $"Kleinste getal: {klein}\n";
                            }
                            output += $"{groot} min {klein} is {groot - klein}";
                        }
                        break;
                }

                Console.WriteLine(output);

                // TODO maar t is vrijdag
                //// Herhaal of niet
                ///
                //string antw;
                //string[] opts = { "y", "n" };
                //do
                //{
                //    Console.Write("Wil je nog een keer? ");
                //    // Vraag opnieuw totdat de input een van YyNn is
                //    antw = Console.ReadLine().ToLower();
                //} while (antw == "y");

                //// If met ternary operator
                //isRepeat = antw.ToLower() == "y" ? true : false;
                
            } while (isRepeat); // herhaal zolang er geen N of n wordt ingegeven

            Console.WriteLine("Hopelijk was alles naar wens.");
            Console.Beep(440, 1000);
            Console.ReadKey();
        }
    }
}
