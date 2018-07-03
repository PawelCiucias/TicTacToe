using pav.tictactoe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.tictactoe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ListView ListView;

        public MenuPage()
        {
            InitializeComponent();

            BindingContext = new MenuPageViewModel();
            ListView = MenuItemsListView;
        }
    }
}