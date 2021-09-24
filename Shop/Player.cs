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

        /// <summary>
        /// Function allows player to buy and item from the shop and add it to their inventory
        /// </summary>
        /// <param name="item">The item the player is buying from the shop</param>
        public void Buy(Item item)
        {
            //Create a new array with one more slot than the old array
            Item[] inventory = new Item[_inventory.Length + 1];

            //Copy the values from the old array into the new array
            for (int i = 0; i < _inventory.Length; i++)
            {
              inventory[i] = _inventory[i];
            }

            //Place new item in the new array
            inventory[_inventory.Length] = item;

            //Set old array equal to the new array
            _inventory = inventory;

            //Subtract the cost of the item from the players gold 
            _gold -= item.Cost;
        }

        /// <returns>List of items in the players inventory</returns>
        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length + 1];

            for(int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }

        /// <summary>
        /// Saves player gold and inventory
        /// </summary>
        /// <param name="writer">StreamWriter</param>
        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_gold);
            writer.WriteLine(_inventory.Length);

            for(int i = 0; i < _inventory.Length; i++)
            {
                writer.WriteLine(_inventory[i].Name);
                writer.WriteLine(_inventory[i].Cost);
            }

        }

        /// <summary>
        /// Loads everything in players most recent save
        /// </summary>
        /// <param name="reader">StreamReader</param>
        /// <returns>Everything that was saved</returns>
        public bool Load(StreamReader reader)
        {
            int inventoryLength = 0;

            if (!int.TryParse(reader.ReadLine(), out inventoryLength))
            {
                return false;
            }

            _inventory = new Item[inventoryLength];

            int i = 0;

            while(!reader.EndOfStream)
            {
                _inventory[i].Name = reader.ReadLine();

                if (!int.TryParse(reader.ReadLine(), out _inventory[i].Cost))
                {
                    return false;
                }

                i++;

            }


            return true;
        }
        
    }
}
