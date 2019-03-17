using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Classes
{
    public class Rose : Flower
    {
        private Color color = Color.MistyRose;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private int height = 0;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Rose(int leftDaysToDed, double price, Color color, int height) : base(leftDaysToDed, price)
        {
            Color = color;
            Height = height;
        }

        public override string ToString()
        {
            return "I'm Rose.";
        }
    }
}
