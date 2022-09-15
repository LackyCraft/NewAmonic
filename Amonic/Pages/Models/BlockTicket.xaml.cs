using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        int idCabainSelect, countPassagerSelect;
        Schedules schedulesToSelect;
        Schedules schedulesOUTSelect;

        public BlockTicket(Schedules schedulesTo, Schedules schedulesOUT, int idCabain, int countPassager)
        {
            InitializeComponent();
            try
            {
                idCabainSelect = idCabain;
                countPassagerSelect = countPassager;
                schedulesToSelect = schedulesTo;
                schedulesOUTSelect = schedulesOUT;
                TextBoxPasportCountry.ItemsSource = AmonicEntities.GetContext().Countries.ToList();

                TextBoxToFrom.Text = schedulesTo.Routes.Airports1.Name;
                TextBoxToTo.Text = schedulesTo.Routes.Airports.Name;
                TextBoxCabinTypeTo.Text = AmonicEntities.GetContext().CabinTypes.Find(idCabain).Name;
                TextBoxDateTo.Text = schedulesTo.Date.ToString();
                TextBoxCabinFlightNumberTo.Text = schedulesTo.FlightNumber;

                if (schedulesOUT != null)
                {
                    TextBoxToReturn.Text = schedulesTo.Routes.Airports1.Name;
                    TextBoxToFromReturn.Text = schedulesTo.Routes.Airports.Name;
                    TextBoxCabinTypeReturn.Text = AmonicEntities.GetContext().CabinTypes.Find(idCabain).Name;
                    TextBoxDateReturn.Text = schedulesTo.Date.ToString();
                    TextBoxCabinFlightNumberReturn.Text = schedulesTo.FlightNumber;
                }
                else
                {
                    StackPanelReturn.Visibility = Visibility.Collapsed;
                    TextBlockReturn.Visibility = Visibility.Collapsed;
                }

            }
            catch
            {
                MessageError.PrintErrorDBConect();
            }

        }

        private void ClickSaveTocket(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < DataGridPassager.Items.Count;i++)
            {
                Tickets newTickets = (DataGridPassager.Items[i] as Tickets);
                AmonicEntities.GetContext().Tickets.Add(newTickets);
                AmonicEntities.GetContext().SaveChanges();
            }
        }

        private void ClickBackSearch(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveAddPassenger(object sender, RoutedEventArgs e)
        {
            DataGridPassager.Items.Remove(DataGridPassager.SelectedItem);
        }

        private void ClickAddPassenger(object sender, RoutedEventArgs e)
        {
            string messageError = "";
            if (TextBoxFirstName.Text.Length < 2)
                messageError = "Введите имя";
            if (TextBoxLastName.Text.Length < 2)
                messageError += "/n Введите фамилию";
            if (TextBoxPasportCountry.SelectedIndex == -1)
                messageError += "/n Выберите страну паспорта";
            if (TextBoxPasportNum.Text.Length != 6)
                messageError += "/n Не корректно введен номер паспорта";
            if (TextBoxPhone.Text.Length != 12)
                messageError += "/n Телефон должен состоять из 12 сиволов";
            if(messageError.Length < 2)
            {
                Tickets newTicket = new Tickets();
                newTicket.UserID = CurrentUser.ID;
                newTicket.ScheduleID = schedulesToSelect.ID;
                newTicket.CabinTypeID = idCabainSelect;
                newTicket.Firstname = TextBoxFirstName.Text;
                newTicket.Lastname = TextBoxLastName.Text;
                newTicket.Phone = TextBoxPhone.Text;
                newTicket.PassportNumber = TextBoxPasportNum.Text;
                newTicket.PassportCountryID = int.Parse(TextBoxPasportCountry.SelectedValue.ToString());
                newTicket.BookingReference = TextBoxLastName.Text[0] + TextBoxFirstName.Text;
                newTicket.Confirmed = true;

                DataGridPassager.Items.Add(newTicket);
            }
            else
            {
                MessageBox.Show(messageError);
            }
        }
    }
}
