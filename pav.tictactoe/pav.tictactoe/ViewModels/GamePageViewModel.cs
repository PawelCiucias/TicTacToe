using pav.tictactoe.Core;
using pav.tictactoe.Models;

namespace pav.tictactoe.ViewModels
{
    class GamePageViewModel : BaseViewModel
    {
        public Game game = new Game();

        public int TopLeft { get => game.Board[0, 0]; }
        public int TopCenter { get => game.Board[0, 1]; }
        public int TopRight { get => game.Board[0, 2]; }

        public int CenterLeft { get => game.Board[1, 0]; }
        public int CenterCenter { get => game.Board[1, 1]; }
        public int CenterRight { get => game.Board[1, 2]; }

        public int BottomLeft { get => game.Board[2, 0]; }
        public int BottomCenter { get => game.Board[2, 1]; }
        public int BottomRight { get => game.Board[2, 2]; }

        public RelayCommand CellSelectedCommand
        {
            get => new RelayCommand(x =>
            {
                var cellId = int.Parse(x.ToString());
                var row = cellId % 3;
                var column = (cellId - row) / 3;

                if (game.PlacePiece(row, column))
                    NotifyPropertyChanged(row, column);
            });
        }

        void NotifyPropertyChanged(int row, int column)
        {
            if (row == 0)
            {
                if (column == 0)
                    base.NotifyPropertyChanged(nameof(TopLeft));
                else if (column == 1)
                    base.NotifyPropertyChanged(nameof(TopCenter));
                else if (column == 2)
                    base.NotifyPropertyChanged(nameof(TopRight));
            }
            else if (row == 1)
            {
                if (column == 0)
                    base.NotifyPropertyChanged(nameof(CenterLeft));
                else if (column == 1)
                    base.NotifyPropertyChanged(nameof(CenterCenter));
                else if (column == 2)
                    base.NotifyPropertyChanged(nameof(CenterRight));
            }
            else if (row ==2)
            {
                if (column == 0)
                    base.NotifyPropertyChanged(nameof(BottomLeft));
                else if (column == 1)
                    base.NotifyPropertyChanged(nameof(BottomCenter));
                else if (column == 2)
                    base.NotifyPropertyChanged(nameof(BottomRight));
            }
        }
    }
}
