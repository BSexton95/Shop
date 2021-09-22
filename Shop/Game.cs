using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Shop
{
    public struct Item
    {
        public string Name;
        public int Cost;
    }
    class Game
    {
        private Player _player;
        private Shop _shop;
        private bool gameOver;
        private int _currentScene;

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }

        /// <summary>
        /// Function used to initialize any starting values by default
        /// </summary>
        private void Start()
        {
            gameOver = false;
            _currentScene = 0;
            InitializeItems();
        }

        /// <summary>
        /// Function is called every time the game loops
        /// </summary>
        private void Update()
        {
            DisplayCurrentScene();
            Console.Clear();
        }

        /// <summary>
        /// Function is called before the application closes
        /// </summary>
        private void End()
        {
            Console.WriteLine("Thanks for shopping!");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Initializes every item in the shop
        /// </summary>
        private void InitializeItems()
        {
            
            //Initialized Sword name and cost 
            Item sword = new Item { Name = "Sword", Cost = 500 };
            //Initialized Shield name and cost
            Item shield = new Item { Name = "Sheild", Cost = 10 };
            //Initialized Health Potion name and cost
            Item healthPotion = new Item { Name = "Health Potion", Cost = 15 };

            //Initialize array
            Item[] _inventory = new Item[] { sword, shield, healthPotion };

            _shop = new Shop(_inventory);

        }

        /// <summary>
        /// Function receives an input from player, the input being the players decision in game
        /// </summary>
        /// <param name="description">The context for the input</param>
        /// <param name="options">The diffirent options the player has to choose from</param>
        /// <returns>The players choose (The input from player)</returns>
        private int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            while(inputReceived == -1)
            {
                //Prints the constext to console for player to see
                Console.WriteLine(description);

                //Prints every option for player to choose from
                for(int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.Write("> ");

                //Get input from player
                input = Console.ReadLine();

                //If player typed an int...
                if(int.TryParse(input, out inputReceived))
                {
                    //...decrement the input and check if it's within the bounds of the array
                    inputReceived--;
                    if(inputReceived < 0 || inputReceived >= options.Length)
                    {
                        //Set input received ot be the default value
                        inputReceived = -1;

                        //Display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                //If the player did't type an int
                else
                {
                    //Set input received to be the default value
                    inputReceived = -1;
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return inputReceived;
        }
        
        /// <summary>
        /// Saves the game
        /// </summary>
        private void Save()
        {
            //Create a new stream writer
            StreamWriter writer = new StreamWriter("SaveData.txt");

            //Save player
            _player.Save(writer);

            //Close writer when done saving
            writer.Close();
        }

        /// <summary>
        /// Loads the game
        /// </summary>
        /// <returns></returns>
        private bool Load()
        {
            //If the file doesn't exist...
            if(!File.Exists("SaveData.txt"))
            {
                //...return false
                return false;
            }
            
            //Create a new reader to read from the text file
            StreamReader reader = new StreamReader("SaveData.txt");

            int gold;

            //If the first line can't be convered into an integer...
            if(!int.TryParse(reader.ReadLine(), out gold))
            {
                //...return false
                return false;
            }

            //Create a new instance of and try to load the player
            _player = new Player(gold);
            if(!_player.Load(reader))
            {
                return false;
            }

            //Close the reader and loading is finished
            reader.Close();

            return true;
        }
        
        /// <summary>
        /// Calls the appropriate functions based on the current scene
        /// </summary>
        private void DisplayCurrentScene()
        {
            switch(_currentScene)
            {
                case 0:
                    DisplayOpeningMenu();
                    break;

                case 1:
                    DisplayShopMenu();
                    break;
            }
        }

        /// <summary>
        /// Displays the optening menu that allows the player to start or load game
        /// </summary>
        private void DisplayOpeningMenu()
        {
            //Prints a greeting and asks player if they want to start or load
            int choice = GetInput("Welcome to the RPG Shop Simulator! What would you like to do?", "Start Shopping", "Load Inventory");

            //If player chooses to start Shooping...
            if (choice == 0)
            {
                //...sets current scene to display shop menu
                _currentScene = 1;
                _player = new Player(100);
            }
            //If player chooses to load inventory...
            else if (choice == 1)
            {
                //...lets player know if load was successfull or not
                if(Load())
                { 
                    Console.WriteLine("Load Successfull!");
                    Console.ReadKey();
                    Console.Clear();
                    _currentScene = 1;
                }
                else
                {
                    Console.WriteLine("Load Failed!");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Function adds two extra options, save game and exit game, after displaying the shops items
        /// </summary>
        /// <returns>The new array that has save game and exit game options</returns>
        private string[] GetShopMenuOptions()
        {
            string[] shopMenuOptions = new string [_shop.GetItemNames().Length];

            for (int i = 0; i < _shop.GetItemNames().Length; i++)
            {
                shopMenuOptions[i] = _shop.GetItemNames()[i];
            }

            string[] addedOptions = new string[shopMenuOptions.Length + 2];

            for(int i = 0; i < shopMenuOptions.Length; i++)
            {
                addedOptions[i] = shopMenuOptions[i];
            }

            addedOptions[shopMenuOptions.Length] = "Save Game";
            addedOptions[shopMenuOptions.Length + 1] = "Exit Game";

            shopMenuOptions = addedOptions;

            return shopMenuOptions;
        }

        /// <summary>
        /// Displays the players 
        /// </summary>
        private void DisplayShopMenu()
        {
            Console.WriteLine("Your Gold: " + _player.Gold);
            Console.WriteLine("Your Inventory: ");
            Console.WriteLine("");

            string[] playerInventory = _player.GetItemNames();

            for (int i = 0; i < _player.GetItemNames().Length; i++)
            {
                Console.WriteLine(playerInventory[i]);
            }

            //Asks player what they would like to purchase and displays all items
            int choice = GetInput("What would you like to purchase?", GetShopMenuOptions());

            if (choice == 0)
            {
                Console.WriteLine("You have purchased a sword!");
                _shop.Sell(_player, 0);
            }
            else if (choice == 1)
            {
                Console.WriteLine("You have purchased a shield!");
                _shop.Sell(_player, 1);
            }
            else if (choice == 2)
            {
                Console.WriteLine("You have purchased a health potion!");
                _shop.Sell(_player, 2);
            }
            else if (choice == 3)
            {
                Save();
                Console.WriteLine("Saved Game");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            else if (choice == 4)
            {
                gameOver = true;
                return;
            }


        }



    }
}
