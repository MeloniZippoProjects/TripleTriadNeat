using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    public interface IPlayer
    {
        Hand Hand { get; set; }
        Move GetNextMove();
        PlayerColor Color { get; set; }
        Board Board { get; set; }
    }
}
