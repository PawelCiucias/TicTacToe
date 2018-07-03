using pav.tictactoe.Models;
using pav.tictactoe.Views;
using System.Collections.ObjectModel;

namespace pav.tictactoe.ViewModels
{
    public class MenuPageViewModel : BaseViewModel {
        public ObservableCollection<BurgerMenuItem> MenuItems { get; set; }

        public MenuPageViewModel() {
            MenuItems = new ObservableCollection<BurgerMenuItem>(new[] {
                new BurgerMenuItem { Id = 0, Title = "Game", TargetType= typeof(GamePage) },
                new BurgerMenuItem { Id = 1, Title = "Settings" },
                new BurgerMenuItem { Id = 2, Title = "Stats" }
            });
        }
    }
}