using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class dal_ConfigManager
    {
        public static string GTG
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MAINDB"].ConnectionString.ToString();
            }
        }
    }
}
