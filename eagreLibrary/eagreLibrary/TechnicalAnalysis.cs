using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eagreLibrary
{
    public static class TechnicalAnalysis
    {
        public static List<Tick> GetEMA(int window, List<Tick> ticks)
        {
            List<Tick> ema = new List<Tick>();

            Decimal factor = 2 / (window + 1);

            Tick temp = new Tick(ticks[window - 1].time, ticks.GetRange(0, window).Average(t => t.price));
            ema.Add(temp);

            for (int i = 1; i < ticks.Count - window; i++)
            {
                temp = new Tick(ticks[window - 1 + i].time, ticks[i + 1].price * factor + ema[ema.Count - 1].price * (1 - factor));
                ema.Add(temp);
            }

            return ema;
        }

        public static List<Tick> GetMACD(List<Tick> ticks)
        {
            var ema12 = GetEMA(12, ticks);
            var ema26 = GetEMA(26, ticks);

            ema12 = ema12.GetRange(14, ema12.Count - 14);

            List<Tick> macd = new List<Tick>();

            foreach (var v in ema12.Zip(ema26, Tuple.Create))
            {
                macd.Add(v.Item1 - v.Item2);
            }

            return macd;
        }
    }
}
