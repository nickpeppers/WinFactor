using System;

namespace WinFactor.Models
{
    public class Issue
    {
        public string Name { get; set; }

        public int Cost { get; set; }
        public int WinFactor { get; set; }

        public double Weight
        {
            get
            {
                var weight = (double)WinFactor / Cost * 100;
                return Math.Round(weight, 2);
            }
        }

        public Issue(string name, int cost, int winFactor)
        {
            Name = name;
            Cost = cost;
            WinFactor = winFactor;
        }
    }
}