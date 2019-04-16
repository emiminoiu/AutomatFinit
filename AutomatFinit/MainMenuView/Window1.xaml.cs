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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void go_To_RegexPage(object sender, RoutedEventArgs e)
        {
            RegexView regexView = new RegexView();
            regexView.Show();
        }

        private void go_To_Automaton(object sender, RoutedEventArgs e)
        {
            FiniteAutomatonView automaton = new FiniteAutomatonView();
            automaton.Show();

        }

    }
}
