using System;
using System.Collections.Generic;
using System.Text;

namespace eagreLibrary
{
    class Asset
    {
        string code;
        string name;
        AssetType type;
        Dictionary<DateTime, Decimal> prices;

        Tick getPrice()
        {
            // TODO: 
            // need to handle situation when the current price is not in the dictionary yet
            // would need IB API to fetch the latest quote

            return new Tick();
        }

        Tick getPrice(DateTime time)
        {
            if (prices.ContainsKey(time))
            {
                return new Tick(time, price);
            }
        }
    }
}
