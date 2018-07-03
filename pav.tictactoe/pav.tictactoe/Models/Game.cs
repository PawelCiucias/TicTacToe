using System;

namespace pav.tictactoe.Models
{
    class Game
    {
        public event EventHandler GameEnded;
        
        public int[,] Board = new int[3, 3];
        public Tuple<int, int>[] WinningCells { get; private set; }
        public string Winner { get; private set; }
        int x = 1;
        int count = 0;
        

        public bool PlacePiece(int row, int col)
        {
            Gaurd(row);
            Gaurd(col);

            if (Board[row, col] != 0)
                return false;

            Board[row, col] = x *= -1;

            if (IsGameOver() || ++count == 9 )
            {
                if (GameEnded != null)
                    GameEnded.Invoke(this, new EventArgs());
            }
            return true;
        }

        public bool IsGameOver()
        {
            var checker = new Func<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>, bool>((x, y, z) =>
            {
                var sum = Board[x.Item1, x.Item2] + Board[y.Item1, y.Item2] + Board[z.Item1, z.Item2];

                if (Math.Abs(sum) == 3)
                {
                    WinningCells = new[] { x, y, z };
                    Winner = Board[x.Item1, x.Item2] == 1 ? "O" : "X";
                    return true;
                }
                return false;
            });

            var TopLeft = new Tuple<int, int>(0, 0);
            var TopCenter = new Tuple<int, int>(0, 1);
            var TopRight = new Tuple<int, int>(0, 2);

            var MiddleLeft = new Tuple<int, int>(1, 0);
            var MiddleCenter = new Tuple<int, int>(1, 1);
            var MiddleRight = new Tuple<int, int>(1, 2);

            var BottomLeft = new Tuple<int, int>(2, 0);
            var BottomCenter = new Tuple<int, int>(2, 1);
            var BottomRight = new Tuple<int, int>(2, 2);

            return checker.Invoke(TopLeft, TopCenter, TopRight) ||
                   checker.Invoke(MiddleLeft, MiddleCenter, MiddleRight) ||
                   checker.Invoke(BottomLeft, BottomCenter, BottomRight) ||
                   checker.Invoke(TopLeft, MiddleLeft, BottomLeft) ||
                   checker.Invoke(TopCenter, MiddleCenter, BottomCenter) ||
                   checker.Invoke(TopRight, MiddleRight, BottomRight) ||
                   checker.Invoke(TopLeft, MiddleCenter, BottomRight) ||
                   checker.Invoke(TopRight, MiddleCenter, BottomLeft);
        }



        public void Gaurd(int coordinate)
        {
            if (coordinate < 0 || coordinate > 2)
                throw new ArgumentOutOfRangeException();
        }
    }
}
