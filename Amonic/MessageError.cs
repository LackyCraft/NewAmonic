using Amonic.Models;
using Amonic.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amonic
{
    internal class MessageError
    {
        public static string ErrrorDBConect = "Warnin 505. Не удалось установить соединение с базой данных";
        public static string NoSelect = "Warnin 422. Выберите хотя бы один элемент из списка";
        public static string GoodLogin = "Вход в систему";
        public static string LogAUT = "Выход из системы";

        public static void PrintErrorDBConect()
        {
            try
            {
            logService newLog = new logService();
            newLog.log = ErrrorDBConect;
            newLog.state = "ERROR";
            newLog.date = DateTime.Now;
            newLog.idUser = CurrentUser.ID;
            AmonicEntities.GetContext().logService.Add(newLog);
            AmonicEntities.GetContext().SaveChanges();
            }
            catch
            {

            }
        }

        public static void PrintInLogLogin()
        {
            try
            {
                logService newLog = new logService();
                newLog.log = GoodLogin;
                newLog.state = "LOGIN";
                newLog.date = DateTime.Now;
                newLog.idUser = CurrentUser.ID;
                AmonicEntities.GetContext().logService.Add(newLog);
                AmonicEntities.GetContext().SaveChanges();
            }
            catch
            {
                
            }
        }

        public static void PrintInLogLogaut()
        {
            try
            {
                logService newLog = new logService();
                newLog.log = LogAUT;
                newLog.state = "LOGAUT";
                newLog.date = DateTime.Now;
                newLog.idUser = CurrentUser.ID;
                AmonicEntities.GetContext().logService.Add(newLog);
                AmonicEntities.GetContext().SaveChanges();

                TrackUser newTrek = new TrackUser();
                newTrek.UserId = Amonic.Pages.Models.CurrentUser.ID;
                newTrek.Login = Amonic.Pages.Models.TrekingLogin.LogIN;
                newTrek.Out = Amonic.Pages.Models.TrekingLogin.LogOUT;
                AmonicEntities.GetContext().TrackUser.Add(newTrek);
                AmonicEntities.GetContext().SaveChanges();
            }
            catch
            {
                
            }

        }

    }
}
