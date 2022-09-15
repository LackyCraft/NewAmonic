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
using Amonic.Models;

namespace Amonic.Pages.Models
{
    /// <summary>
    /// Логика взаимодействия для BlockTicket.xaml
    /// </summary>
    public partial class BlockTicket : Window
    {
        public BlockTicket(Schedules schedulesTo, Schedules schedulesOUT, int idCabain, int countPassager)
        {
            InitializeComponent();
        }

        private void ClickAddPassenger(object sender, RoutedEventArgs e)
        {

        }
    }
}
