using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Werter.Problems.Solutions.Iniciante.Celulas_1018;

namespace Werter.Problems.Tdd.Iniciante
{
    [TestClass]
    public class Celulas_1018_Testes
    {
        [TestMethod]
        public void DeveObter5NotasDe100Reais()
        {
            var caixaEletronico = new CaixaEletronico();
            var notas = caixaEletronico.ObterQuantidadeMinimaDeNotas(500, Notas.De100);
            notas.Should().Be(5);            
        }

        [TestMethod]
        public void DeveObter10NotasDe50Reais()
        {
            var caixaEletronico = new CaixaEletronico();
            var notas = caixaEletronico.ObterQuantidadeMinimaDeNotas(500, Notas.De50);
            notas.Should().Be(10);
        }
    }
}
