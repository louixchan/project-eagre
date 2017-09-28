using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace eagreLibrary
{
    public class Asset
    {
        string exchange;
        string code;
        string name;
        AssetType type;
        List<Tick> ticks;

        Tick lastTick;

        public Asset()
        {
        }

        public DateTime getEarliestDate()
        {
            return ticks.Min(t => t.time);
        }

        public Tick getNextTick(Tick tick)
        {
            return ticks[ticks.IndexOf(tick) + 1];
        }

        public Tick getPrice()
        {
            // TODO: 
            // need to handle situation when the current price is not in the dictionary yet
            // would need IB API to fetch the latest quote

            return ticks[ticks.Count - 1];
        }

        /// <summary>
        /// Get price of the asset at a specific time. Null returned in case if no available
        /// data at the specific timestamp.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Tick containing the quote at time specified.</returns>
        public Tick getPrice(DateTime time)
        {
            if (ticks.Exists(t => t.time == time))
            {
                return ticks.First(t => t.time == time);
            }

            return null;
        }

        public List<Tick> getMACD()
        {
            return TechnicalAnalysis.GetMACD(ticks);
        }

        public List<Tick> getEMA(int window)
        {
            return TechnicalAnalysis.GetEMA(window, ticks);
        }

        public void readPricesFromCsv(string filename, int columnDate = 0, int columnQuote = 1)
        {
            var lines = File.ReadLines(filename);
            var dictionary = lines.Select(line => line.Split(',')).ToDictionary(data => data[columnDate], data => data[columnQuote]);
        }

        public void readPricesFromJson(string filename)
        {
            using (FileStream s = new FileStream(filename,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();

                        this.ticks = serializer.Deserialize<List<Tick>>(jr);
                    }
                }
            }
        }
    }
}
