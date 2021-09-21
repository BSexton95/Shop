using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public struct Item
    {
        public int Cost;
        public string Name;
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

        private void Start()
        {
            gameOver = false;
            _currentScene = 0;
            InitalizeItems();
        }

        private void Update()
        {

        }

        private void End()
        {

        }

        private void InitalizeItems()
        {
            //Sword 
            Item sword = new Item { 500g, "Sword" };
            //Shield
            Item shield = new Item { 10g, "Sheild" };
            //Health Potion
            Item healthPotion = new Item { 15g, "Health Potion" };

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

        private void Save()
        {

        }

        private bool Load()
        {

        }

        private void DisplayCurrentScene()
        {

        }

        private void DisplayOpeningMenu()
        {
            //Prints a greeting and asks player if they want to start or load
            int choice = GetInput("Welcome to the RPG Shop Simulator! What would you like to do?", "Start Shopping", "Load Inventory");

            //If player chooses to start Shooping...
            if (choice == 0)
            {
                //...sets current scene to _____ and brings up the shop for player
                _currentScene = ;
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
                    _currentScene = ;
                }
                else
                {
                    Console.WriteLine("Load Failed!");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        private string[] GetShopMenuOptions()
        {
               
        }

        private void DisplayShopMenu()
        {

        }


    }
}
