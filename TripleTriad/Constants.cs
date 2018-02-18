using System;

namespace TripleTriad
{
    public static class Constants
    {
        /// <summary>
        /// Enum for game rules
        /// </summary>
        [Flags]
        public enum Rules
        {
            None = 0,
            Plus = 1,
            Same = 2,
            Samewall = 4,
            Elemental = 8,
            Open = 16,
            One = 32,
            All = 64,
            Direct = 128,
            Difference = 256,
            Random = 1024
        }

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

        /// <summary>
        /// Sides of a card
        /// </summary>
        public enum CardSide
        {
            Top,
            Right,
            Bottom,
            Left
        }

        public const double ElementAppearRate = 0.15;
        public const int ElementsNumber = (int) Element.Ice + 1;
    }
    
}