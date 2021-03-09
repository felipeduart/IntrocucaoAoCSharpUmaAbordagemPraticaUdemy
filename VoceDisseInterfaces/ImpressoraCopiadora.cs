using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceDisseInterfaces
{
    public class ImpressoraCopiadora : IImpressora, ICopiadora
    {
        public string Copiar(string texto)
        {
            return $"texto a copiar: {texto}";
        }

        public string Imprimir(string texto)
        {
            return $"texto a imprimir: {texto}";
        }
    }
}
