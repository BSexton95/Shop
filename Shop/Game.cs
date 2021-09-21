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

        }

        private void Update()
        {

        }

        private void End()
        {

        }

        private void InitalizeItems()
        {

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

        }

        private string[] GetShopMenuOptions()
        {

        }

        private void DisplayShopMenu()
        {

        }


    }
}
