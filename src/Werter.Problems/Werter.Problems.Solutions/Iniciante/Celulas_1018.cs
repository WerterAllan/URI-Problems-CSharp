using System;

namespace Werter.Problems.Solutions.Iniciante
{
    public class Celulas_1018
    {

        public class CaixaEletronico
        {                   
            public void MostrarNotas(decimal valor)
            {
                Console.WriteLine("{0} nota(s) de R$ 100,00", ObterQuantidadeMinimaDeNotas(ref valor, Notas.De100));
                Console.WriteLine("{0} nota(s) de R$ 50,00",  ObterQuantidadeMinimaDeNotas(ref valor, Notas.De50));
                Console.WriteLine("{0} nota(s) de R$ 20,00",  ObterQuantidadeMinimaDeNotas(ref valor, Notas.De20));
                Console.WriteLine("{0} nota(s) de R$ 10,00",  ObterQuantidadeMinimaDeNotas(ref valor, Notas.De10));
                Console.WriteLine("{0} nota(s) de R$ 5,00",   ObterQuantidadeMinimaDeNotas(ref valor, Notas.De5));
                Console.WriteLine("{0} nota(s) de R$ 2,00",   ObterQuantidadeMinimaDeNotas(ref valor, Notas.De2));
                Console.WriteLine("{0} nota(s) de R$ 1,00",   ObterQuantidadeMinimaDeNotas(ref valor, Notas.De1));
            }

            public int ObterQuantidadeMinimaDeNotas(ref decimal valor, Notas nota)
            {
                
                if (valor < 0)
                    return 0;

                var qtdNotas = 0;
                var valorNota = (int)nota;

                while (valor > valorNota - 1)
                {
                    qtdNotas++;
                    valor -= valorNota;
                }

                return qtdNotas;
            }
        }

        public enum Notas
        {
            De100 = 100,
            De50 = 50,
            De20 = 20,
            De10 = 10,
            De5 = 5,
            De2 = 2, 
            De1 = 1
        }

        
    }
}


