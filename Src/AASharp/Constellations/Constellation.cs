using System;

namespace AASharp.Constellations
{
    [Obsolete("This class has been moved into a new project : AASharp.Extension")]
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