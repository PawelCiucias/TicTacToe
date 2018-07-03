using System;
using pav.tictactoe.Views;

namespace pav.tictactoe.Models
{
    public class BurgerMenuItem
    {
        public BurgerMenuItem() => TargetType = typeof(GamePage);
        
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}