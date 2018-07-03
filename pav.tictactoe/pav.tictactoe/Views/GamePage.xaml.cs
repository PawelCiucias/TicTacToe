using pav.tictactoe.Models;
using pav.tictactoe.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.tictactoe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        GamePageViewModel vm;

        public GamePage()
        {
            InitializeComponent();
            vm = this.BindingContext as GamePageViewModel;
        }

        private async void Game_GameEnded(object sender, System.EventArgs e)
        {
            var game = sender as Game;
            await Animate(game.WinningCells);

            if (game.WinningCells == null)
                await DisplayAlert("Tie Game", "There is no winner", "ok");
            else
            {
                await DisplayAlert("Winner", $"{game.Winner} is the winner", "ok");
            }
        }

        private async Task Animate(Tuple<int, int>[] WinningCells)
        {
            var buttons = new List<Button>(new[] {
                 TopLeft_Button, TopCenter_Button, TopRight_Button,
                 MiddleLeft_Button, MiddleCenter_Button, MiddleRight_Button,
                 BottomLeft_Button, BottomCenter_Button, BottomRight_Button
            });

            if (WinningCells != null)
                for (int i = WinningCells.Length - 1; i > -1; i--)
                {
                    var winner = WinningCells[i];

                    buttons.RemoveAt(winner.Item1 * 3 + winner.Item2);
                }


            foreach (var button in buttons)
                button.FadeTo(0.4);

            await Task.Delay(500);

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Game_Grid.HeightRequest = Game_Grid.WidthRequest = -20 + width > height ? this.Height : this.Width;
        }

        protected override void OnAppearing()
        {
            vm.game.GameEnded += Game_GameEnded;
        }

        protected override void OnDisappearing()
        {
            vm.game.GameEnded -= Game_GameEnded;
        }
    }
}