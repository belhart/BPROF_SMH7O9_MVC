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

        public override bool Equals(object obj)
        {
            if (obj is ElertPont)
            {
                ElertPont other = obj as ElertPont;
                return this.DriverName == other.DriverName &&
                    this.Points == other.Points;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}