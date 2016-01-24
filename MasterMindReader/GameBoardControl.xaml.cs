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
    /// Interaction logic for GameBoardControl.xaml
    /// </summary>
    public partial class GameBoardControl : UserControl
    {
        private GameBoard data;

        public GameBoardControl()
        {
            InitializeComponent();
        }

        public GameBoard Data
        {
            get { return data; }
            set
            {
                data = value;

                foreach(var elementControl in GameGrid.Children.OfType<GameBoardElementControl>())
                {
                    int i = Grid.GetRow(elementControl);
                    int j = Grid.GetColumn(elementControl);
                    elementControl.Data = data.Elements[i, j];
                }
            }
        }

        private void UserControl_Click(object sender, RoutedEventArgs e)
        {
            var elementControl = (GameBoardElementControl)e.Source;
            int i = Grid.GetRow(elementControl);
            int j = Grid.GetColumn(elementControl);
        }
    }
}
