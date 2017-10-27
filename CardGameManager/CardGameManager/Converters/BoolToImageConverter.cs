using System;
using CardGameManager.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CardGameManager.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        public Brush CardBackBrush { get; set; }
        public Brush CardBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush imageBrush = null;
            if (targetType == typeof(Brush))
            {
                CardModel card = (CardModel)value;
                if (!card.IsFlipped)
                {
                    imageBrush = CardBackBrush;
                }
                else
                {
                    imageBrush = CardBrush;
                }
            }

            return imageBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
