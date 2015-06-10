using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript_EnDecoder
{
    class Item
    {//we need a item class to handle items easier
        private ItemType Type; //this will store the Item type lol
        public int ID;
        public string name;
        public int HealValue;//Hearts gained
        public enum ItemType
        {
            Eatable,
            Usable
        };
        public Item(int ID, ItemType Type, int HealVal, string name, int OffsetX, int OffsetY, string texture = ""/*redundant(?) for now*/)
        {
            this.ID = ID;
            this.HealValue = HealVal;
            this.name = name;
            this.Type = Type;
        }
        //finished
        public bool canEat()
        {
            if (this.Type == ItemType.Eatable)
                return true;
            return false;
        }
    }
}
