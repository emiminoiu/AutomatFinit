using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegexView.xaml
    /// </summary>
    public partial class RegexView : Window
    {
        public RegexView()
        {
            InitializeComponent();
        }

        private void checkResult(object sender, RoutedEventArgs e)
        {
            int selected = 0;
            string input = inputBox.Text.ToString();
            string pattern = patternBox.Text.ToString();
           
            if (btnIgnoreCase.IsChecked == true)
            {
                selected++;             
                bool found = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
                if (found)
                {
                    input = input.ToLower();
                    pattern = input.ToLower();
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
                    
                }
                else
                {
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
                }

            }
            

            if (btnIgnoreWhitespace.IsChecked == true)
            {
                selected++;              
                bool found = Regex.IsMatch(input,pattern, RegexOptions.IgnorePatternWhitespace);
                if (found)
                {
                    input = input.Trim();
                    pattern = input.Trim();
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);

                }
                else
                {
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
                }
            }
            if (btnMultiline.IsChecked == true)
            {
                selected++;
                bool found = Regex.IsMatch(input, pattern, RegexOptions.Multiline);
                if (found)
                {
                    MessageBox.Show("found");
                }
             
                if (found)
                {
                    pattern = pattern.Trim();
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
                }
                else
                {
                    MatchCollection matches = Regex.Matches(input, pattern);
                    MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
                }
                
            }
            if (btnRightToLeft.IsChecked == true)
            {
                selected++;
            }
            if (btnSingleline.IsChecked == true)
            {
                selected++;
            }

            if (btnNoFilter.IsChecked == true)
            {
                selected++;
                MatchCollection matches = Regex.Matches(input, pattern);
                MessageBox.Show("There was " + matches.Count + " matches for " + pattern);
            }

            if (selected == 0)
            {
                MessageBox.Show("Select one option!");
            }






        }
    }
}
