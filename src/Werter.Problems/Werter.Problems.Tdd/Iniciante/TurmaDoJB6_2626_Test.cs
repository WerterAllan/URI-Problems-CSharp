using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Werter.Problems.Solutions.Iniciante.TurmaDoJB6_2626;

namespace Werter.Problems.Tdd.Iniciante
{
    [TestClass]
    [TestCategory("Iniciante - 2626")]
    public class TurmaDoJB6_2626_Test
    {
        private AvaliadorJokenpo MontarNovoJogo(Jokenpo jogadaDoDodo, Jokenpo jogadaDoLeo, Jokenpo jogadaDoPepper)
        {
            return new AvaliadorJokenpo(jogadaDoDodo, jogadaDoLeo, jogadaDoPepper);
        }

        [TestMethod]
        public void DeveRetornarUmEmpatePara3JogadasDiferentes()
        {
            var avaliadorJokenpo = new AvaliadorJokenpo(
                Jokenpo.Papel, Jokenpo.Pedra, Jokenpo.Tesoura
                );

            avaliadorJokenpo.OuveEmpate()
                .Should().BeTrue();
        }

        [TestMethod]
        public void DeveRetornarUmEmpatePara3Iguais()
        {
            var avaliadorJokenpo = new AvaliadorJokenpo(
                Jokenpo.Papel, Jokenpo.Papel, Jokenpo.Papel
                );

            avaliadorJokenpo.OuveEmpate()
                .Should().BeTrue();
        }

        [TestMethod]
        public void DeveRetornarPapelParaDuasPedraEUmPapel()
        {
            MontarNovoJogo(Jokenpo.Papel, Jokenpo.Pedra, Jokenpo.Pedra)
                .BuscarVencedor()
                .ShouldBeEquivalentTo(Jokenpo.Papel);
        }

        [TestMethod]
        public void DeveRetornarPedraParaDuasTesouras()
        {
            MontarNovoJogo(Jokenpo.Tesoura, Jokenpo.Tesoura, Jokenpo.Pedra)
                .BuscarVencedor()
                .ShouldBeEquivalentTo(Jokenpo.Pedra);
        }

        [TestMethod]
        public void DeveRetornarTesouraParaDoisPapeis()
        {
            MontarNovoJogo(Jokenpo.Papel, Jokenpo.Tesoura, Jokenpo.Papel)
                .BuscarVencedor()
                .ShouldBeEquivalentTo(Jokenpo.Tesoura);
        }

        [TestMethod]
        public void DeveExtrairJogadasDaString()
        {
            var jogadas = "pedra, papel, tesoura";
            new ExtratorDeJogadas()
                .Extrair(jogadas)
                .Should()
                .Contain(Jokenpo.Pedra)
                .And                
                .Contain(Jokenpo.Papel)
                .And
                .Contain(Jokenpo.Tesoura);
                
                
        }

        [TestMethod]
        public void DeveRetornarOTextoDoDodo()
        {
            new Jogo()
                .Jogar("pedra, tesoura, tesoura")
                .Should()
                .BeEquivalentTo(TEXTO_VITORIA_DO_DODO);
        }

        [TestMethod]
        public void DeveRetornarOTextoDoLeo()
        {
            new Jogo()
                .Jogar("papel, tesoura, papel")
                .Should()
                .BeEquivalentTo(TEXTO_VITORIA_DO_LEO);
        }

        [TestMethod]
        public void DeveRetornarOTextoDoPepper()
        {
            new Jogo()
                .Jogar("pedra, pedra, papel")
                .Should()
                .BeEquivalentTo(TEXTO_VITORIA_DO_PEPPER);
        }

        [TestMethod]
        public void DeveRetornarOTextoDeEmpate()
        {
            new Jogo()
                .Jogar("pedra, papel, tesoura")
                .Should()
                .BeEquivalentTo(TEXTO_EMPATE);
        }
    }
}
