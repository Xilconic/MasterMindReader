using BoardGameEngine;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MasterMindReader
{
    /// <summary>
    /// Interaction logic for GameBoardElementControl.xaml
    /// </summary>
    public partial class GameBoardElementControl : UserControl, IObserver<ElementState>
    {
        private GameBoardElement data;
        private IDisposable unsubscriber;

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
                if (unsubscriber != null)
                {
                    unsubscriber.Dispose();
                }

                data = value;

                label.Content = data.ElementValue;
                SecondaryValueColor.Color = GetColorForSecondaryValue(data);
                UpdateImageOverlayForGameState(data.State);

                unsubscriber = data.Subscribe(this);
            }
        }

        public void OnNext(ElementState value)
        {
            UpdateImageOverlayForGameState(value);
        }

        public void OnError(Exception error)
        {
            // Do nothing with errors.
        }

        public void OnCompleted()
        {
            unsubscriber.Dispose();
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

        private void UpdateImageOverlayForGameState(ElementState newState)
        {
            switch(newState)
            {
                case ElementState.Empty:
                    image.Source = null;
                    break;
                case ElementState.Yes:
                    SetImageSourceFromResource("Yes.png");
                    break;
                case ElementState.NotValue:
                    SetImageSourceFromResource("CrossedOut.png");
                    break;
                case ElementState.NotRow:
                    SetImageSourceFromResource("NotRow.png");
                    break;
                case ElementState.NotColumn:
                    SetImageSourceFromResource("NotColumn.png");
                    break;
                case ElementState.NeitherRowNorColumn:
                    SetImageSourceFromResource("NeitherRowNorColumn.png");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void SetImageSourceFromResource(string imageFileName)
        {
            BitmapImage overlay = new BitmapImage();
            overlay.BeginInit();
            overlay.UriSource = new Uri("pack://application:,,,/AssemblyName;component/Resources/"+ imageFileName);
            overlay.EndInit();
            image.Source = overlay;
        }
    }
}
