namespace Werter.Problems.Solutions.Iniciante
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TurmaDoJB6_2626
    {
        public const string TEXTO_VITORIA_DO_DODO = "Os atributos dos monstros vao ser inteligencia, sabedoria...";
        public const string TEXTO_VITORIA_DO_LEO = "Iron Maiden’s gonna get you, no matter how far!";
        public const string TEXTO_VITORIA_DO_PEPPER = "Urano perdeu algo muito precioso...";
        public const string TEXTO_EMPATE = "Putz vei, o Leo ta demorando muito pra jogar...";

        public enum Jokenpo
        {
            Pedra,
            Papel,
            Tesoura,
            Empate
        }


        public class Jogo
        {
            private IList<Jogador> _jogadores = new List<Jogador>();

            public string Jogar()
            {
                var entrada = Console.ReadLine();
                return Jogar(entrada);
            }

            public string Jogar(string entrada)
            {
                var jogadas = new ExtratorDeJogadas().Extrair(entrada);

                this._jogadores.Add(new Jogador("Dodo", jogadas[0], TEXTO_VITORIA_DO_DODO));
                this._jogadores.Add(new Jogador("Leo", jogadas[1], TEXTO_VITORIA_DO_LEO));
                this._jogadores.Add(new Jogador("Pepper", jogadas[2], TEXTO_VITORIA_DO_PEPPER));
                this._jogadores.Add(new Jogador("Empate", Jokenpo.Empate, TEXTO_EMPATE));

                var vencedor = new AvaliadorJokenpo(jogadas)
                    .BuscarVencedor();

                var textoVencedor = BuscaTextoDoVencedor(vencedor);
                return textoVencedor;
            }

            private string BuscaTextoDoVencedor(Jokenpo JogadaVencedora)
            {
                var vencedor = _jogadores
                    .First(x => x.Jogada == JogadaVencedora);
                return vencedor.Texto;
            }
        }

        public sealed class ExtratorDeJogadas
        {
            public IList<Jokenpo> Extrair(string entrada)
            {
                var jogadas = entrada.Split(',')
                    .Select(x => ConverterParaJokenpo(x))
                    .ToList();

                return jogadas;
            }

            private Jokenpo ConverterParaJokenpo(string jogada)
            {
                Jokenpo x = (Jokenpo)Enum.Parse(typeof(Jokenpo), jogada, true);
                return x;

            }
        }

        public sealed class AvaliadorJokenpo
        {
            private readonly IList<Jokenpo> _jogadas;

            public AvaliadorJokenpo(IList<Jokenpo> jogadas)
            {
                _jogadas = jogadas;
            }

            public AvaliadorJokenpo(Jokenpo jogador1, Jokenpo jogador2, Jokenpo jogador3)
            {

                this._jogadas = new List<Jokenpo>
                {
                    jogador1,
                    jogador2,
                    jogador3
                };

            }

            public Jokenpo BuscarVencedor()
            {
                var papelVencedor = PapelFoiVencedor();
                if (papelVencedor)
                    return Jokenpo.Papel;

                var pedraVenceu = PedraFoiVencedora();
                if (pedraVenceu)
                    return Jokenpo.Pedra;

                var tesouraVenceu = TesouraFoiAVencedora();
                if (tesouraVenceu)
                    return Jokenpo.Tesoura;

                return Jokenpo.Empate;

            }

            private bool TesouraFoiAVencedora()
            {
                return TemAsSeguintesJogadas(Jokenpo.Papel, Jokenpo.Tesoura);
            }

            private bool PedraFoiVencedora()
            {
                return TemAsSeguintesJogadas(Jokenpo.Tesoura, Jokenpo.Pedra);

            }

            private bool PapelFoiVencedor()
            {
                return TemAsSeguintesJogadas(Jokenpo.Pedra, Jokenpo.Papel);
            }

            private bool TemAsSeguintesJogadas(Jokenpo duasDeste, Jokenpo umDeste)
            {
                var temDuasPedras = _jogadas
                                    .Count(x => x == duasDeste) == 2;

                var temPapel = _jogadas.Contains(umDeste);

                return temDuasPedras && temPapel;
            }

        }

        public sealed class Jogador
        {
            public Jogador(string nome, Jokenpo jogada, string texto)
            {
                this.Nome = nome;
                this.Jogada = jogada;
                this.Texto = texto;
            }

            public string Nome { get; }
            public Jokenpo Jogada { get; }
            public string Texto { get; }
        }
    }
}
