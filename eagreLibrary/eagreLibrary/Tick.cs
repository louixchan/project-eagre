using System;

namespace eagreLibrary
{
    public class Tick
    {
        public DateTime time;
        public Decimal price;

        public Tick()
        {

        }

        public Tick(DateTime time, Decimal price)
        {
            this.time = time;
            this.price = price;
        }

        public override string ToString()
        {
            if (time != null)
                return "Time: " + time.ToShortDateString() + "\nPrice: " + price.ToString();
            return base.ToString();
        }

        public static Tick operator -(Tick a, Tick b)
        {
            if (a.time != b.time)
            
                return null;

            else
            {
                a.price -= b.price;
                return a;
            }
        }

        public static Tick operator -(Tick a, Decimal b)
        {
            if (a == null)

                return null;

            else
            {
                a.price -= b;
                return a;
            }
        }

        public static Tick operator +(Tick a, Tick b)
        {
            if (a.time != b.time)

                return null;

            else
            {
                a.price += b.price;
                return a;
            }
        }

        public static Tick operator +(Tick a, Decimal b)
        {
            if (a == null)

                return null;

            else
            {
                a.price += b;
                return a;
            }
        }
    }
}
