using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    class Game
    {
        public Board Board { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }

        public Game(Board board, IPlayer player1, IPlayer player2)
        {
            Board = board;
            Player1 = player1;
            Player2 = player2;
        }

        public IPlayer StartGame()
        {
            IPlayer[] players = new IPlayer[2] { Player1, Player2 };

            //the game is made by 9 moves
            for (int i = 0; i < 9; ++i)
            {
                IPlayer player = players[i % 2];
                Move move = player.GetNextMove();
                Board.PlayMove(move);   //todo: this can throw. Handle or prevent this
            }

            return Board.GetWinner();
        }
    }
}
