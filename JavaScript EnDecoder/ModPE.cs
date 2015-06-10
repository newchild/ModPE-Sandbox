using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript_EnDecoder
{
    class ModPE
    {
        
        private List<Item> Items = new List<Item>();//generate a list later
        private List<Block> Blocks = new List<Block>();
        public  void setItem(int id, string texture, int offset, string name){
            Items.Add(new Item(id,Item.ItemType.Usable, 0, name, offset,0));
            StaticUtils.log("Successfully added the Item " + name + " as an Item. It's item ID is " + id);//need to rework this later
        }
        //lets define a FoodItem


		public ModPE()
		{

		}

		public ModPE(List<Item> v1, List<Block> v2)
		{
			Items = v1;
			Blocks = v2;
		}

		public List<Item> getItems()
		{
			return Items;
		}

		public List<Block> getBlocks()
		{
			return Blocks;
		}

		public void setFoodItem(int id, int X, int Y, int heal, string text)//function prototype should be obvious :P
        {
            Items.Add(new Item(id, Item.ItemType.Eatable, heal, text, X, Y));
            StaticUtils.log("Successfully added the Item " + text + " as a Food. It's item ID is " + id + ". It will heal you for " + Convert.ToDecimal(heal/2) + " hearts");
            //and this is it basically 

        }


    }
}
