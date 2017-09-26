using System;
using System.Collections.Generic;
using System.Text;

namespace eagreLibrary
{
    class Order
    {
        ActionType actionType;
        OrderType orderType;

        Asset asset;
        Decimal price;
        int quantity;

        DateTime orderTime;
        DateTime executionTime;

        int execute()
        {
            executionTime = DateTime.Now;
            return 0;
        }

        int execute(DateTime time)
        {
            executionTime = time;
            return 0;
        }
    }
}
