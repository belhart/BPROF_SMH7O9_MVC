namespace F1Stats.Logic
{
    public class ElertPont
    {
        public string DriverName { get; set; }

        public int Points { get; set; }

        public override string ToString()
        {
            return this.DriverName + " " + this.Points.ToString();
        }
    }
}