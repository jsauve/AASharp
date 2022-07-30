namespace AASharp
{
    public class AASMoonNodesDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            Ascending = 1,
            Descending = 2
        };

        /// <summary>
        /// The type of the event which has occurred
        /// </summary>
        public Type type { get; set; } = Type.NotDefined;

        /// <summary>
        /// When the event occurred in TT
        /// </summary>
        public double JD { get; set; } = 0;
    }
}