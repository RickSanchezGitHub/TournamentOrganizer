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

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Логика взаимодействия для TabItemGridOfTournaments.xaml
    /// </summary>
    public partial class TabItemGridOfTournaments : TabItem
    {
        public TabItemGridOfTournaments()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if ((string)button.Content == "Разрешить матч")
            {
                button.Content = "Выберите победителя";
            }
            else
            {

            }
            var data = button.DataContext;
            var father = button.Parent;

        }
    }
}
