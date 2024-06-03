using PokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerGame.ViewModels
{
    public class HowToPlayViewModel : BaseViewModel
    {
        public HowToPlayViewModel()
        {
            RestartCommand = new RestartCommand(this);
        }

        public ICommand RestartCommand { get; set; }
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    OnPropertyChanged(nameof(SelectedViewModel));
                }
            }
        }

        public ObservableCollection<string> Rules { get; set; } = new ObservableCollection<string>
        {
            "Pair (Пара. Дві карти одного рангу) = 5 очок", "Two Pairs (Дві пари одного рангу та дві пари іншого) = 10 очок",
            "Three of a kind (Сет. Три карти одного рангу) = 15 очок", "Straight (Стріт. П’ять послідовних карт, але різної масті) = 20 очок",
            "Flush (Флеш. П’ять карт однієї масті, але не послідовних) = 25 очок", "Full House (Фул Хаус. Три карти одного рангу та дві іншого. Сет + пара) = 30 очок",
            "Four of a kind (Каре. Чотири карти одного рангу) = 35 очок", "Straight flush (Стріт-флеш. П’ять послідовних карт однієї масті) = 40 очок",
            "Royal Straight Flush (Флеш-рояль. Послідовність від 10 до Туза. Карти однієї масті) = 50 очок!"
        };

        public ObservableCollection<string> HowToPlay { get; set; } = new ObservableCollection<string>
        {
            "'Five Card Draw (Файв Кард Дроу)' - це карткова гра, мета якої - зібрати \"руку\" якомога кращого рангу\"",
            "\"Рука\" складається з п'яти карт",
            "Гравець намагається зібрати \"руку\", міняючи карти місцями - викидаючи непотрібні і тягнучи нові випадкові карти",
            "Різні \"руки\", які може зібрати гравець, ранжуються - див. \"Ранжування рук\" в другій таблиці нижче",
            "Кожна \"рука\" дає гравцеві певну кількість очок",
            "Гравець намагається зібрати якомога більшу кількість очок",
            "Перед початком гри гравець має обрати бажану складність",
            "Складність базується на кількості розіграшів, які гравець може зробити (1, 2 або 3)",
            "Ви повинні вибрати, яким гравцем ви хочете грати, вибравши існуючого гравця або створивши нового",
            "Потім натисніть \"Почати гру\"",
            "Гра починається з роздачі 5 випадкових карт з колоди гравцеві",
            "Поточні бали та рейтинг \"руки\" відображаються у верхній частині екрана",
            "Потім ви перетягуєте карти, які хочете поміняти, до позначеної на екрані зони",
            "Щоб взяти нові карти з колоди, натисніть на перевернуту червону карту зправа, яка з’явиться, якщо принаймні одна карта замінюється",
            "Якщо вас влаштовує роздача і у вас залишилися роздачі, ви можете натиснути кнопку \"Закінчити гру\"",
            "Коли гра закінчиться, буде показано результат вашої \"руки\" та місце в таблиці рекордів"
        };
    }
}
