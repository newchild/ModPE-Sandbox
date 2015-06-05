using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript_EnDecoder
{
    class ModPE
    {

        private static List<int> Items = new List<int>(Enumerable.Range(256, 245).ToList());
        private static List<int> Blocks = new List<int>(Enumerable.Range(0, 255).ToList());
        public static void setItem(int id, string texture, int offset, string name){
            if (Items.Contains(id) || Blocks.Contains(id))
            {
                StaticUtils.log("The id " + id + " seems to be already in use. Please take care!");
                return;
            }
            Items.Add(id);
            StaticUtils.log("Successfully added the Item " + name + " as an Item. It's item ID is " + id);
        }

    }
}
