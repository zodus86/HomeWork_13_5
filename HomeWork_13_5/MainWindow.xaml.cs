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

namespace HomeWork_13_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank bank;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();

            bank.CreateBank();
           
            lvClient.ItemsSource = bank.clients;
            lvPersons.ItemsSource = bank.persons;
            lvAccount.ItemsSource = bank.bankAccounts;
            
        }
        
        /// <summary>
        /// Закрыть открыть счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAccount_Click(object sender, RoutedEventArgs e)
        {
            bank.bankAccounts[lvAccount.SelectedIndex].IOpen = !(bank.bankAccounts[lvAccount.SelectedIndex].IOpen);

            lvAccount.Items.Refresh();
            lvClient.Items.Refresh();
        }
        
        /// <summary>
        /// перевести
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Transactions(ulong.Parse(AccountIn.Text), decimal.Parse(AccountFromValue.Text));
            Transactions(ulong.Parse(AccountOut.Text), -(decimal.Parse(AccountFromValue.Text)));
            lvAccount.Items.Refresh();
            lvClient.Items.Refresh();
        }

       /// <summary>
       /// Внести деньги
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Transactions(ulong.Parse(AccountIn.Text), decimal.Parse(AccountFromValue.Text));
            lvAccount.Items.Refresh();
            lvClient.Items.Refresh();
        }

        /// <summary>
        /// зачислисть деньги
        /// </summary>
        /// <param name="account"></param>
        /// <param name="value"></param>
        private void Transactions(ulong account, decimal value)
        {
            for(int i= 0; i< bank.bankAccounts.Count(); i++)
            {
                if (bank.bankAccounts[i].Account == account)
                    bank.bankAccounts[i].Value += value;
            }
        }
        /// <summary>
        /// Увелечения долгов и накоплений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BankAccount<Person> bankAccount = bank.clients.ElementAt(lvClient.SelectedIndex).Key;
            var tenProcent = bankAccount.Value / 100 * 10;
            
            bankAccount.Value += (tenProcent);

            lvAccount.Items.Refresh();
            lvClient.Items.Refresh();
        }
    }
}