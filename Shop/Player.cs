using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        public Player(int gold)
        {
            _gold = gold;
            _inventory = new Item[0];
        }
        
        public void Buy(Item item)
        {

            Item[] inventory = new Item[_inventory.Length + 1];

            for (int i = 0; i < _inventory.Length; i++)
            {
              inventory[i] = _inventory[i];
            }

            inventory[inventory.Length - 1] = item;

            
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length + 1];

            for(int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            

            return itemNames;
        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_gold);
            writer.WriteLine(_inventory);
        }

        public bool Load(StreamReader reader)
        {
            if (!int.TryParse(reader.ReadLine(), out _gold))
            {
                return false;
            }

            

            return true;
        }
        
    }
}
