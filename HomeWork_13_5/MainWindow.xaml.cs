using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BankLibrary;

namespace HomeWork_13_5
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Action<string> AddLog;
        Bank bank;
        ObservableCollection<string> logs;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
            bank.CreateBank();
            logs = new ObservableCollection<string>();
            AddLog = CreateLogs;
            
            AddLog?.Invoke(bank.Print());

            lvLogs.ItemsSource = logs;
            lvClient.ItemsSource = bank.clients;
            lvPersons.ItemsSource = bank.persons;
            lvAccount.ItemsSource = bank.bankAccounts;

            //Сумма первых счетов
            decimal sum = bank.bankAccounts[0] + bank.bankAccounts[1];

            //Библиотека
            string randomStr = RandomStr.RandomText();
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


            string logs = $"Теперь счет {bank.bankAccounts[lvAccount.SelectedIndex].Account} сотсояние {bank.bankAccounts[lvAccount.SelectedIndex].IOpen}";
            AddLog?.Invoke(logs);
        }
        
        /// <summary>
        /// перевести
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPerevod(object sender, RoutedEventArgs e)
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
        private void ButtonDeposit(object sender, RoutedEventArgs e)
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
                {
                    bank.bankAccounts[i].Value += value;
                    string logs = $"Произведена транзакция по счету {bank.bankAccounts[i].Account} на сумму : {value} баланс : {bank.bankAccounts[i].Value}";
                    AddLog?.Invoke(logs);
                }
            }


        }
        /// <summary>
        /// Увелечения долгов и накоплений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClicOnClient(object sender, MouseButtonEventArgs e)
        {
            BankAccount<Person> bankAccount = bank.clients.ElementAt(lvClient.SelectedIndex).Key;
            var tenProcent = bankAccount.Value / 100 * 10;
            
            bankAccount.Value += (tenProcent);

            lvAccount.Items.Refresh();
            lvClient.Items.Refresh();

            string logs = $"Выполнина банковская операция по счету {bankAccount.Account} на сумму : {tenProcent} баланс : {bankAccount.Value}";
            AddLog?.Invoke(logs);

        }

        /// <summary>
        /// метод для делегата
        /// </summary>
        /// <param name="str">строка изменений для лога</param>
        public void CreateLogs(string str)
        {
            MessageBox.Show(str);
            logs.Add($"{DateTime.Now}_{str}");
        }
    }
}