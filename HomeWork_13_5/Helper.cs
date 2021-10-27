using System.Text;

namespace HomeWork_13_5
{   
    /// <summary>
    /// класс расширения
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// метод расширения для банка
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static string Print (this Bank bank)
        {
            StringBuilder stringBuilder = new StringBuilder("В вашем банке находятся следуйщие клиенты:\n");
            foreach (var para in bank.clients)
                stringBuilder.Append($"{para.Key.Account} - {para.Value.FullName} ");

            stringBuilder.Append($"\nВсего {bank.persons.Count} - контрагентов" +
                                $" и {bank.bankAccounts.Count} - банковских счетов");

            return stringBuilder.ToString();
        }

    }
}
