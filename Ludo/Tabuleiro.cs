using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Tabuleiro
    {
        public Jogador[] VJ;
        public int [] CasasSeguras = { 1, 9, 14, 22, 27, 35, 40, 48 };
        public string[] Cores = { "Vermelho", "Verde", "Amarelo", "Azul" };
        public bool vencedor = false;

        public Tabuleiro(int NJogadores, string [] nomes)
        {
            VJ = new Jogador[NJogadores];
            if (NJogadores == 2)
            {
                for (int i = 0, j = 0; i < VJ.Length; i++, j+=2)
                {
                    this.VJ[i] = new Jogador(nomes[i], this.Cores[j], j);
                }
            }
            else
            {
                for(int i = 0; i < VJ.Length; i++)
                {
                    this.VJ[i] = new Jogador(nomes[i], this.Cores[i], i);
                }
            }
            
        }
        //public bool VerificarVencedor(int posicao_do_jogador)
        //{
        //    int cont_Peoes_Vencedores = 0;

        //    for(int i =0; i < VJ[iPeao].Peoes_Vencedores.Length; i++)
        //    {
        //        if(VJ[i].Peoes_Vencedores[i] != 0)
        //        {
        //            cont_Peoes_Vencedores++;
        //        }
        //    }

        //}
        public bool VerificaDado(int vDado)
        {
            if(vDado == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int EscolherPeao()
        {
            int peao;
            do
            {
                Console.Write($"\nEscolha um peão para jogar: ");
                peao = int.Parse(Console.ReadLine());
                if(peao < 0 && peao > 5)
                {
                    Console.WriteLine("Peão inválido!");
                }
                return peao - 1;
            } while (peao < 0 && peao > 5);
        }
        public int EscolherDado(int []vDados)
        {
            if (vDados[0] < 6 && vDados[1] == 0 && vDados[2] == 0)
                return vDados[0];

            else if (vDados[1] < 6 && vDados[0] == 0 && vDados[2] == 0)
                return vDados[1];

            else if (vDados[2] < 6 && vDados[1] == 0 && vDados[0] == 0)
                return vDados[2];

            else
            {
                int dado;
                foreach (int valorDado in vDados)
                {
                    if (valorDado > 0)
                        Console.Write($"Dado: {valorDado} ");
                }
                do
                {
                    Console.Write("\nEscolha o dado: ");
                    dado = int.Parse(Console.ReadLine());

                    if (dado != vDados[0] && dado != vDados[1] && dado != vDados[2])
                    {
                        Console.WriteLine("Escolha inválida!");
                    }
                } while (dado != vDados[0] && dado != vDados[1] && dado != vDados[2]);

                for (int i = 0; i < vDados.Length; i++)
                {
                    if (vDados[i] == dado)
                    {
                        vDados[i] = 0;
                        break;
                    }
                }
                return dado;
            }
        }
        public void ImprimirInfoPeoes(int id, int[] vDados)
        {
            if (vDados[0] == 6 || vDados[1] == 6 || vDados[2] == 6 || VJ[id].VP[0].PeaoSolto() == true || VJ[id].VP[1].PeaoSolto() == true || VJ[id].VP[2].PeaoSolto() == true || VJ[id].VP[3].PeaoSolto() == true)
            {
                Console.WriteLine("---Peões---\n");
                foreach (Peao peoes in VJ[id].VP)
                {

                    if (vDados[0] == 6 || vDados[1] == 6 || vDados[2] == 6)
                    {
                        Console.WriteLine($"{peoes.id + 1}° Peão: {peoes.pos}");
                    }
                    else
                    {
                        if (peoes.PeaoSolto() == true)
                        {
                            Console.WriteLine($"{peoes.id + 1}° Peão: {peoes.pos}");
                        }
                    }
                }
                Console.WriteLine("\n----FIM----\n");
            }
        }
        public void CapturaPeao()
        {

        }
        
    }
}
