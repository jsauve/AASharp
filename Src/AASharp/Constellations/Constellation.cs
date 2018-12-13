namespace AASharp.Constellations
{
    public class Constellation
    {
        public Constellation(string abbreviation, string name, string genitive)
        {
            Name = name;
            Genitive = genitive;
            Abbreviation = abbreviation;
        }

        public string Name { get; } 
        public string Genitive { get; } 
        public string Abbreviation { get; } 
    }
}