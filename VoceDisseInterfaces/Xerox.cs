using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceDisseInterfaces
{
    public class Xerox : ICopiadora
    {
        public string Copiar(string texto)
        {
            return $"Texto a copiar:{texto} ";
        }
    }
}
