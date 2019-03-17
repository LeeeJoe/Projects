using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Flower
    {
        private int leftDaysToDead = 0;
        public int LeftDaysToDead
        {
            get { return leftDaysToDead; }
            protected set { leftDaysToDead = value; }
        }

        private double price = 1;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Flower() : this(0, 1)
        {

        }

        public Flower(int leftDaysTodead, double price)
        {
            LeftDaysToDead = leftDaysToDead;
            Price = price;
        }

        public double GetPrice()
        {
            return Price;
        }

        public int LeftDays()
        {
            return LeftDaysToDead;
        }
    }
}
