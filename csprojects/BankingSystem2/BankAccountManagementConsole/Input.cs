using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementConsole
{
    public class Input
    {
        public static T Read<T>(string prompt, T defaultValue=default(T))
        {
            try
            {
                
                Console.Write(prompt);
                var ans = Console.ReadLine();
                return (T)Convert.ChangeType(ans, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
