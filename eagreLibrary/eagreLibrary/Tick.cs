using System;

namespace eagreLibrary
{
    public class Tick
    {
        DateTime time;
        Decimal price;

        Tick(DateTime time, Decimal price)
        {
            this.time = time;
            this.price = price;
        }
    }
}
