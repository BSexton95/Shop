using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop(Item[] inventory)
        {
            _inventory = inventory;
        }
        
        public bool Sell(Player player , int option)
        {
            if(player.Gold < _inventory[option].Cost)
            {
                Console.WriteLine("You don't have enough gold!");
            }
            else
            {
                player.Buy(_inventory[option]);
            }

            Console.ReadKey(true);
            Console.Clear();

            return true; 

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
