using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesGamer
{
    internal class Validaciones
    {
        public static bool textVacios(TextBox pTxt) {
            if (pTxt.Text == string.Empty)
            {
                pTxt.Focus();
                return true;
            }
            else {
                return false;
            }

        }
        public static bool validarEmail(string pCorreo)
        {
            return pCorreo != null && Regex.IsMatch(pCorreo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


    }
}
