using PokerGame.ViewModels;

namespace PokerGame.Models
{

    public class Player : BaseViewModel
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
