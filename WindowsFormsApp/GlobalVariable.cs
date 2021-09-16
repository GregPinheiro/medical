using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class GlobalVariable
    {
        public static string connectionString = @"Data Source=localhost;Initial Catalog=BancoDados;Persist Security Info=True;User ID=sa;Password=@dmin";
        public static string userName;
    }
}
