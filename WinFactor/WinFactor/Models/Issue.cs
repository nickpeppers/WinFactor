namespace WinFactor.Models
{
    public class Issue
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int WinFactor { get; set; }
        public double Weight { get { return (double)Cost / WinFactor; } }
    }
}