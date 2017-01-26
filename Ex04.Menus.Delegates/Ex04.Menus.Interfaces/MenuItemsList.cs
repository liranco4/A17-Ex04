﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemsList : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        protected string m_backOrExitMsgToUser = "Back";
            
        public MenuItemsList(string i_MenuHeaderName)
            : base(i_MenuHeaderName)
        {
        }

        internal override void ExecuteActionOrSubMenu()
        {
            StringBuilder MenuToPrint = new StringBuilder();

            if (r_MenuItems != null)
            {
                int Lineindex = 0;

                do
                {
                    Lineindex = 1;
                    MenuToPrint.AppendLine(string.Format("{0}{1}", MenuName, "=============="));

                    foreach (MenuItem Item in r_MenuItems)
                    {
                        MenuToPrint.Append(string.Format("{0}- {1}{2}", Lineindex, Item.MenuName, Environment.NewLine));
                        Lineindex++;
                    }

                    MenuToPrint.Append(string.Format("0. {0}{1}", m_backOrExitMsgToUser, Environment.NewLine));
                    MenuToPrint.Append(string.Format("Please enter input from menu (between 0 to {0}{1}):", r_MenuItems.Count, Environment.NewLine));
                    Console.Write(MenuToPrint);
                }
                while (!manipulateUserInput());

                Console.Clear();
            }
            else
            {

            }
        }

        private bool manipulateUserInput()
        {
            bool backOrExitFlag = false;
            int userChoice;

            userChoice = CheckUserInput();
            if (userChoice == 0)
            {
                backOrExitFlag = true;
            }
            else
            {
                Console.Clear();
                r_MenuItems[userChoice - 1].ExecuteActionOrSubMenu();
            }

            return backOrExitFlag;
        }


        private int CheckUserInput()
        {
            bool isInputValid = true;
            bool loopFlag = true;
            int userInput = 0;
            do
            {
                isInputValid = int.TryParse(Console.ReadLine(), out userInput);

                if (!isInputValid && userInput >= 0 && userInput <= r_MenuItems.Count)
                {
                    loopFlag = false;
                    Console.Write("Please enter valid input:");
                }
                else
                {
                    loopFlag = true;
                }
            }
            while (!loopFlag);

            return userInput;
        }


        public void AddItemToMenu(MenuItem i_MenuItemToAdd)
        {
            r_MenuItems.Add(i_MenuItemToAdd);
        }

    }
}