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

        private int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            return intputReceived;
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
