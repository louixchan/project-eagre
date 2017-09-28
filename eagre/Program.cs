using System;
using eagreLibrary;
using System.Collections.Generic;

namespace eagre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Asset vix = new Asset();
            vix.readPricesFromJson(@"C:\Users\lchan1\Downloads\vixcurrent.json");
            Console.WriteLine(vix.getPrice().ToString());

            Asset gold = new Asset();
            gold.readPricesFromJson(@"C:\Users\lchan1\Downloads\goldcurrent.json");
            Console.WriteLine(gold.getPrice().ToString());

            DateTime start = vix.getEarliestDate() > gold.getEarliestDate() ? vix.getEarliestDate() : gold.getEarliestDate();

            List<Tick> vixMACD = vix.getMACD();
            List<Tick> vixSignal = TechnicalAnalysis.GetEMA(9, vixMACD);

            List<Tick> goldMACD = gold.getMACD();
            List<Tick> goldSignal = TechnicalAnalysis.GetEMA(9, goldMACD);
            
            Console.ReadLine();
        }
    }
}
