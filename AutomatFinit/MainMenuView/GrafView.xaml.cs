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
using System.Windows.Shapes;

namespace AutomatFinit.MainMenuView
{
    /// <summary>
    /// Interaction logic for GrafView.xaml
    /// </summary>
    public partial class GrafView : Window
    {
        public GrafView()
        {
            InitializeComponent();
        }

        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
           
                Ellipse ellipse = sender as Ellipse;
                if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(ellipse,
                                         ellipse.Fill.ToString(),
                                         DragDropEffects.Copy);
                }
            
        }

        private void ellipse_Drop(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, 
                    // convert it and apply it to the ellipse.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }

        private Brush _previousFill = null;
        private void ellipse_DragEnter(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
                _previousFill = ellipse.Fill;

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, convert it.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }

        private void ellipse_DragLeave(object sender, DragEventArgs e)
        {
            
                Ellipse ellipse = sender as Ellipse;
                if (ellipse != null)
                {
                    ellipse.Fill = _previousFill;
                }
            
        }

        private void ellipse_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, allow copying.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
                }
            }
        }

        private void ellipse_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }
    }
}
