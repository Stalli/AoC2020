namespace AoC2020
{
    public class Bag
    {
        public string Shade { get; set; }
        public string Color { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var qwe = (Bag) obj;
            return qwe.Color == Color && qwe.Shade == Shade;
        }
    }
}