using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using static PokerGame.Models.Card;

namespace PokerGame.Converter
{

    public class CardToImageConverter : IValueConverter
    {
        /// <summary>
        /// Перетворює значення RecreateCardFromCardView у рядок і використовує властивості, щоб знайти потрібну картинку і відобразити її на CardView.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Card && value != null)
            {
                return _ = new BitmapImage(new Uri(@"/Resources/ImagesCards/" + value.ToString() + ".png", UriKind.Relative));
            }
            return null;
        }
        //Не використовується
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
