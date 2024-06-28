using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Jogador
    {
        public int id;
        public string nome;
        public string cor;
        public Peao[] VP = new Peao[4];
        public Peao[] Peoes_Vencedores = new Peao[4];
        public bool AlgumPeaoSolto = false;

        public Jogador(string nome, string cor, int id)
        {
            this.nome = nome;
            this.cor = cor;
            this.id = id;

            for (int i = 0; i < VP.Length; i++)
            {
                this.VP[i] = new Peao(i, -1);
            }
        }
        public int JogarDado(Random dado)
        {
            int vDado = dado.Next(1, 7);

            return vDado;
        }
        public bool VerificaPeaoSolto()
        {
            for(int i = 0; i < VP.Length; i++)
            {
                if(VP[i].pos != -1)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
