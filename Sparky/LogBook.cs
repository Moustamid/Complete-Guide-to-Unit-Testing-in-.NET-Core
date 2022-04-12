using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    //-Interface :
    public interface ILogBook
    {
        void Message(string message);
        bool LogToDb(string message);
        
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        
        string MessageWithReturnStr(string message);
        
        bool LogWithOutputResult(string str, out string outputStr);
        
        bool LogWithRefObj(ref Customer customer);
    }
    
    //-Classes : 
    public class LogBook : ILogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("failure");
            return false;
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

    }
    
 
}