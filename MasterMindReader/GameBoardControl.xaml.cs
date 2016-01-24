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

        public static readonly RoutedEvent ElementClickEvent = EventManager.RegisterRoutedEvent(
            "ElementClick", RoutingStrategy.Bubble, typeof(GameBoardControlElementClickEventHandler), typeof(GameBoardControl));

        public event GameBoardControlElementClickEventHandler ElementClick
        {
            add { AddHandler(ElementClickEvent, value); }
            remove { RemoveHandler(ElementClickEvent, value); }
        }

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
            var elementControl = e.OriginalSource as GameBoardElementControl;
            if (elementControl != null)
            {
                RaiseElementClickEvent(elementControl);
            }
        }

        private void RaiseElementClickEvent(GameBoardElementControl elementControl)
        {
            int rowIndex = Grid.GetRow(elementControl);
            int columnIndex = Grid.GetColumn(elementControl);
            var newEventArgs = new GameBoardControlElementClickEventArgs(ElementClickEvent, rowIndex, columnIndex);
            RaiseEvent(newEventArgs);
        }

        public delegate void GameBoardControlElementClickEventHandler(object sender, GameBoardControlElementClickEventArgs e);

        public sealed class GameBoardControlElementClickEventArgs : RoutedEventArgs
        {
            public GameBoardControlElementClickEventArgs(RoutedEvent routedEvent, int rownIndex, int columnIndex) : base(routedEvent)
            {
                RowIndex = rownIndex;
                ColumnIndex = columnIndex;
            }

            public int RowIndex { get; private set; }

            public int ColumnIndex { get; private set; }
        }
    }
}
