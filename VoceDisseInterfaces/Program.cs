using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceDisseInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = new ImpressoraComum();
            var i2 = new ImpressoraCopiadora();
            
            Console.WriteLine(i.Imprimir("estou estudando C#"));
            Console.WriteLine(i2.Copiar("estou estudando C# e gostando"));
        }

        public static void CopiarDocumento(ICopiadora c, string texto)
        {
            Console.WriteLine("estou copiando o texto a seguir: " + c.Copiar(texto));
        }

    }
}
