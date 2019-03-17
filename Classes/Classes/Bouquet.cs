using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Bouquet
    {
        private bool goodReason = true;
        public bool GoodReason
        {
            get { return goodReason; }
            set { goodReason = value; }
        }

        private double price = 0;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private List<Flower> flowers;
        public List<Flower> Flowers
        {
            get { return flowers; }
            set { flowers = value; }
        }

        public Bouquet()
        {
            Flowers = new List<Flower>();
        }

        public Bouquet(bool goodReason, double price, List<Flower> flowers)
        {
            GoodReason = goodReason;
            Price = price;
            Flowers = flowers;
        }

        public Bouquet(bool goodReason, List<Flower> flowers)
        {
            GoodReason = goodReason;

            for (int i = 0; i < flowers.Count; i++)
            {
                Price += flowers[i].Price;
            }

            Flowers = flowers;
        }

        public Bouquet(List<Flower> flowers)
        {
            GoodReason = flowers.Count % 2 != 0;

            for (int i = 0; i < flowers.Count; i++)
            {
                Price += flowers[i].Price;
            }

            Flowers = flowers;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void AddFlower(Flower flower)
        {
            if (flower == null)
            {
                throw new ArgumentException("Please specify flower...");
            }

            Flowers.Add(flower);
            Price += flower.Price;
        }

        public void RemoveFlower(Flower flower)
        {
            if (flower == null)
            {
                throw new ArgumentException("Please specify flower...");
            }

            Flowers.Remove(flower);
            Price -= flower.Price;
        }

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Flowers.Count; i++)
            {
                s += Flowers[i].ToString() + Environment.NewLine;
            }

            return s;
        }
    }
}
