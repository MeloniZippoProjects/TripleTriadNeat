namespace TripleTriad
{
    public static class Constants
    {
        /// <summary>
        /// Enum for element types
        /// </summary>
        public enum Element
        {
            None,
            Earth,
            Fire,
            Water,
            Poison,
            Holy,
            Lightning,
            Wind,
            Ice
        }

        /// <summary>
        /// Color of the Player
        /// </summary>
        public enum PlayerColor
        {
            Red,
            Blue,
            None
        }

        public const double ElementAppearRate = 0.15;
        public const int ElementsNumber = (int) Element.Ice + 1;
    }
    
}