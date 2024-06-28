using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Peao
    {
        public int id;
        public int pos;

        public Peao(int id, int pos)
        {
            this.id = id;
            this.pos = pos;
        }
        public bool MoverPeao(int dado)
        {
            if(pos == -1 && dado < 6)
            {
                Console.WriteLine("Não pode mover o peão, pois esta preso!\n");
                return false;
            }
            else if(pos == -1 && dado == 6)
            {
                this.pos = 1;
                return true;
            }
            else
            {
                this.pos += dado;
                return true;
            }
        }
        public bool PeaoSolto()
        {
            if(this.pos == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
