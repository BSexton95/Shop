using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Item[] Inventory
        {
            get { return _inventory; }
        }

        public Shop(Item[] )
        {

        }

        public bool Sell(Player , int )
        {

        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];

            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }
    }
}
