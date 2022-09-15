﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Amonic.Models;
using Amonic.Pages;

namespace Amonic.Pages
{
    public partial class AddUserWindows : Window
    {
        public AddUserWindows()
        {
            InitializeComponent();
            try
            {
                ComboBoxOffice.ItemsSource = AmonicEntities.GetContext().Offices.ToList();
            }
            catch
            {
                MessageBox.Show(MessageError.ErrrorDBConect);
                MessageError.PrintErrorDBConect();
            }
        }

        private void ClickCancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickSaveButton(object sender, RoutedEventArgs e)
        {
            string messageError = "";
            if (PasswordBoxPassword.Password.Length < 8)
                messageError += "Пароль должен состоять более, чем из 8 символов";
            if (TextBoxEmail.Text.Length < 2)
                messageError += "\n Не заполнен Email";
            if (TextBoxFirstName.Text.Length < 2)
                messageError += "\n Не заполнено имя";
            if (TextBoxLastName.Text.Length < 2)
                messageError += "\n Не заполнено фамилия";
            if (ComboBoxOffice.SelectedIndex == -1)
                messageError += "\nВыберите офис";

            DateTime dateBirthday;
            if (!DateTime.TryParse(DataPickerBirthdey.Text, out dateBirthday))
                messageError += "\nВыберите дату рождения";
            if (messageError.Length > 2)
            {
                MessageBox.Show(messageError);
            }
            else
            {
                try
                {
                    Users newUser = new Users();
                    newUser.Email = TextBoxEmail.Text;
                    newUser.FirstName = TextBoxFirstName.Text;
                    newUser.LastName = TextBoxLastName.Text;
                    newUser.Birthdate = dateBirthday;
                    newUser.Password = PasswordBoxPassword.Password;
                    newUser.RoleID = 2;
                    newUser.OfficeID = int.Parse(ComboBoxOffice.SelectedValue.ToString());
                    newUser.Active = true;

                    AmonicEntities.GetContext().Users.Add(newUser);
                    AmonicEntities.GetContext().SaveChanges();
                    (this.Owner as AdminPanelWindow).updateAllMaterialList();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(MessageError.ErrrorDBConect);
                    MessageError.PrintErrorDBConect();
                }
            }
        }
    }
}
