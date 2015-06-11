using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript_EnDecoder
{
	[Serializable]
    class Block
    {
        public int ID, Data;
        public Block(int id, int Data)
        {
            this.Data = Data;
            this.ID = id;
        }
    }
}
