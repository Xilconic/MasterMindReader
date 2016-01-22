using BoardGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterMindReader
{
    /// <summary>
    /// Interaction logic for GameBoardElementControl.xaml
    /// </summary>
    public partial class GameBoardElementControl : UserControl
    {
        private GameBoardElement data;

        public GameBoardElementControl()
        {
            InitializeComponent();
        }

        public GameBoardElement Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;

                label.Content = data.ElementValue;
                SecondaryValueColor.Color = GetColorForSecondaryValue(data);
            }
        }

        private Color GetColorForSecondaryValue(GameBoardElement data)
        {
            if (data.SecondaryElementValue == 1)
            {
                return Colors.Yellow;
            }
            else if (data.SecondaryElementValue == 2)
            {
                return Colors.Chocolate;
            }
            else if (data.SecondaryElementValue == 3)
            {
                return Colors.Lime;
            }
            else if (data.SecondaryElementValue == 4)
            {
                return Colors.LightPink;
            }
            else if (data.SecondaryElementValue == 5)
            {
                return Colors.Firebrick;
            }
            throw new NotImplementedException();
        }
    }
}
