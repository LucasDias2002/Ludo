using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random dado = new Random();
            int qtsJogadores;
            do
            {
                Console.Write("Jogarão 2 ou 4 jogadores?\nDigite: ");
                qtsJogadores = int.Parse(Console.ReadLine());

                if(qtsJogadores != 2 && qtsJogadores != 4)
                {
                    Console.WriteLine("Quantidade de jogadores inválida!\n");
                }
            } while (qtsJogadores != 2 && qtsJogadores != 4);
            Console.Clear();

            Console.WriteLine("Quantidade de Jogadores Definida!");

            string[] nomes= new string[qtsJogadores];
            for(int i = 0; i < qtsJogadores; i++)
            {
                Console.WriteLine($"\nDigite o nome do {i+1}° jogador: ");
                nomes[i] = Console.ReadLine();
            }

            Tabuleiro Jogo = new Tabuleiro(qtsJogadores, nomes);
            Console.Clear();

            //Teste
            Console.WriteLine("--------------Jogadores disponiveis------------");
            for (int i = 0; i < Jogo.VJ.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}° Jogador || Nome: {Jogo.VJ[i].nome}, cor: {Jogo.VJ[i].cor}, id: {Jogo.VJ[i].id}\n");
            }
            Console.WriteLine("-----------------------------------------------");
            int id =0;
            Console.ReadLine();
            do
            {
                Console.Clear();
                int[] vDados = {0, 0, 0};
                int peao;
                int dado_escolhido;
                Console.WriteLine($"Jogador {Jogo.VJ[id].nome} lance o dado: ");
                Console.WriteLine("Pressione enter para lançar o dado");
                Console.ReadLine();
                int vDado = Jogo.VJ[id].JogarDado(dado);
                vDados[0] = vDado;
                Console.Write($"Dado: {vDado}");
                Console.ReadLine();

                if (Jogo.VerificaDado(vDado))
                {
                    Console.WriteLine($"Lance o dado novamente: ");
                    Console.WriteLine("Pressione enter para lançar o dado");
                    Console.ReadLine();
                    vDado = Jogo.VJ[id].JogarDado(dado);
                    vDados[1] = vDado;
                    Console.WriteLine($"Dado: {vDado}");
                    Console.ReadLine();

                    if (Jogo.VerificaDado(vDado))
                    {
                        vDado = Jogo.VJ[id].JogarDado(dado);
                        vDados[2] = vDado;
                        Console.WriteLine($"Dado: {vDado}");
                        Console.ReadLine();

                        if (Jogo.VerificaDado(vDado))
                        {
                            Console.WriteLine("Passa a vez por tirar seis por 3 vezes seguidas!");

                            id++;
                            if (id == qtsJogadores && Jogo.vencedor != true)
                                id = 0;
                        }
                        else
                        {
                            for (int i = 0; i < vDados.Length; i++)
                            {
                                if (vDados[i] != 0)
                                {
                                    Jogo.ImprimirInfoPeoes(id, vDados);
                                    if (Jogo.VJ[id].VerificaPeaoSolto() || vDados[0] == 6 || vDados[1] == 6 || vDados[2] == 6)
                                    {
                                        peao = Jogo.EscolherPeao();
                                        dado_escolhido = Jogo.EscolherDado(vDados);
                                        Jogo.VJ[id].VP[peao].MoverPeao(dado_escolhido);
                                    }
                                    Console.ReadLine();
                                }
                            }
                            id++;
                            if (id == qtsJogadores && Jogo.vencedor != true)
                                id = 0;
                        }
                    }
                    else
                    {
                        for(int i = 0; i < vDados.Length; i++)
                        {
                            if(vDados[i] != 0)
                            {
                                Jogo.ImprimirInfoPeoes(id, vDados);
                                if (Jogo.VJ[id].VerificaPeaoSolto() || vDados[0] == 6 || vDados[1] == 6 || vDados[2] == 6)
                                {
                                    peao = Jogo.EscolherPeao();
                                    dado_escolhido = Jogo.EscolherDado(vDados);
                                    Jogo.VJ[id].VP[peao].MoverPeao(dado_escolhido);
                                }
                                Console.ReadLine();
                            }
                        }
                        id++;
                        if (id == qtsJogadores && Jogo.vencedor != true)
                            id = 0;
                    }
                }
                else
                {
                    Jogo.ImprimirInfoPeoes(id, vDados);
                    if (Jogo.VJ[id].VerificaPeaoSolto() || vDados[0] == 6 || vDados[1] == 6 || vDados[2] == 6)
                    {
                        peao = Jogo.EscolherPeao();
                        Jogo.VJ[id].VP[peao].MoverPeao(vDado);
                    }
                    Console.ReadLine();
                    id++;
                    if (id == qtsJogadores && Jogo.vencedor != true)
                        id = 0;
                }
            } while (Jogo.vencedor != true);
        }
    }
}
