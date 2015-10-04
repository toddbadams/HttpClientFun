namespace Client.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string First { get; set; }

        public string Last { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", First, Last, Id);
        }
    }
}