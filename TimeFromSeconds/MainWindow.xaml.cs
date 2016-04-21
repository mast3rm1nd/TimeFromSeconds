using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Numerics;
using System.Text.RegularExpressions;

namespace TimeFromSeconds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        string GetTimePeriodFromSeconds(BigInteger seconds)
        {
            ulong minute = 60;
            ulong hour = 60 * minute;
            ulong day = 24 * hour;
            ulong month = 30 * day;
            ulong year = 12 * month;

            var secondsLeft = seconds;

            string result = "";

            if (seconds == 0)
                return "0 секунд =)";

            if (secondsLeft / year != 0)
            {
                result += String.Format("лет: {0}", secondsLeft / year) + "\n";
                secondsLeft = secondsLeft % year;
            }

            if (secondsLeft / month != 0)
            {
                result += String.Format("месяцев: {0}", secondsLeft / month) + "\n";
                secondsLeft = secondsLeft % month;
            }

            if (secondsLeft / day != 0)
            {
                result += String.Format("дней: {0}", secondsLeft / day) + "\n";
                secondsLeft = secondsLeft % day;
            }

            if (secondsLeft / hour != 0)
            {
                result += String.Format("часов: {0}", secondsLeft / hour) + "\n";
                secondsLeft = secondsLeft % hour;
            }

            if (secondsLeft / minute != 0)
            {
                result += String.Format("минут: {0}", secondsLeft / minute) + "\n";
                secondsLeft = secondsLeft % minute;
            }

            if (secondsLeft != 0)
            {
                result += String.Format("секунд: {0}", secondsLeft);
            }


            if (result[result.Length - 1] == '\n')               //избавляемся от "\n", если имеется вконце
                return result.Substring(0, result.Length - 1);
            else
                return result;
        }

        private void TextBox_Seconds_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(TextBox_Seconds.Text, @"^\d+$"))
                TextBox_Result.Text = GetTimePeriodFromSeconds(BigInteger.Parse(TextBox_Seconds.Text));
            else
                TextBox_Result.Text = "Введите целое число секунд";
        }
    }
}
