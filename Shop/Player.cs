using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;

        public int Gold
        {
            get { return _gold; }
        }

        public Item[] Inventory
        {
            get { return _inventory; }
        }

        public Player(int gold)
        {
            _gold = gold;
        }

        public void Buy(Item item)
        {
            string[] inventory = new string[_inventory.Length + 1];
            int i;

            for (i = 0; i < _inventory.Length; i++)
            {
               inventory[i] = _inventory[i];
            }

            inventory[i] = item;

            
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length ];

            for(int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }

        public void Save(StreamWriter writer)
        {

        }

        public bool Load(StreamReader reader)
        {

        }
    }
}
