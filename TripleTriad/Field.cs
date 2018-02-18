using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    public class Field
    {
        /// <summary>
        /// If this field is not null, it contains the card placed
        /// on the field.
        /// </summary>
        private Card card;
        public Card Card
        {
            get => card;
            set
            {
                card = value;
                Card.ParentField = this;
            }
        }

        /// <summary>
        /// The Board which hosts this Field instance
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// The Board row in which this field exists
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// The Board column in which this field exists
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// If this field is not null, it contains the element
        /// assigned to the field
        /// </summary>
        public Element Element { get; set; } = Element.None;

        /// <summary>
        /// If this field is not null, it contains the
        /// color of the player
        /// </summary>
        public PlayerColor Color { get; set; } = PlayerColor.None;

        public bool IsWall { get; set; }

        public Field Above { get; set; }
        public Field Below { get; set; }
        public Field LeftSide { get; set; }
        public Field RightSide { get; set; }

        //todo: could be cached for performance
        public IEnumerable<Boundary> Boundaries => new List<Boundary>()
        {
            new Boundary()
            {
                Origin = this,
                Neighbour = Above,
                OriginSide = CardSide.Top,
                NeighbourSide = CardSide.Bottom
            },
            new Boundary()
            {
                Origin = this,
                Neighbour = RightSide,
                OriginSide = CardSide.Right,
                NeighbourSide = CardSide.Left
            },
            new Boundary()
            {
                Origin = this,
                Neighbour = Below,
                OriginSide = CardSide.Bottom,
                NeighbourSide = CardSide.Top
            },
            new Boundary()
            {
                Origin = this,
                Neighbour = LeftSide,
                OriginSide = CardSide.Left,
                NeighbourSide = CardSide.Right
            }
        };

        public IEnumerable<Boundary> ActiveBoundaries => Boundaries.Where(b => b.IsActive);

        public bool IsFree => Color == PlayerColor.None;

        public void Flip()
        {
            if (!IsWall && Color != PlayerColor.None)
                Color = (Color == PlayerColor.Blue) ? PlayerColor.Red : PlayerColor.Blue;
        }
    }

    public class Boundary
    {
        public Field Origin;
        public Field Neighbour;
        public CardSide OriginSide;
        public CardSide NeighbourSide;

        public bool IsActive => Origin.Card != null && Neighbour.Card != null;

        public bool IsBaseRuleCapture => 
            IsActive && Origin.Color != Neighbour.Color &&
            Origin.Card.GetSide(OriginSide) > Neighbour.Card.GetSide(NeighbourSide);

        public bool IsSameCandidate =>
            IsActive && Origin.Card.GetSide(OriginSide) == Neighbour.Card.GetSide(NeighbourSide);

        public uint Sum => 
            IsActive ? 0 : Origin.Card.GetSide(OriginSide) + Neighbour.Card.GetSide(NeighbourSide);
    }
}
