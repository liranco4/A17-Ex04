﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemsList : MenuItem
    {
        private const string k_Back = "Back";
        private const int k_Zero = 0;
        private const int k_One = 1;

        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuItemsList(string i_MenuHeaderName)
            : base(i_MenuHeaderName)
        {
        }

        protected virtual string BackOrExitMsgToUser
        {
            get
            {
                return k_Back;
            }
        }

        public void AddItemToMenuList(MenuItem i_MenuItemToAdd)
        {
            this.r_MenuItems.Add(i_MenuItemToAdd);
        }

        internal override void ExecuteActionOrShowSubMenu()
        {
            StringBuilder menuToPrint = new StringBuilder();
            bool backOrExitFlag = false;
            int userChoice;

            if (this.r_MenuItems != null)
            {
                int lineindex = k_Zero;

                do
                {
                    lineindex = k_One;
                    menuToPrint.AppendLine(string.Format("{0}{1}{2}", this.MenuName, Environment.NewLine, "====================="));
                    menuToPrint.Append(string.Format("0. {0}{1}", this.BackOrExitMsgToUser, Environment.NewLine));
                    foreach (MenuItem item in this.r_MenuItems)
                    {
                        menuToPrint.Append(string.Format("{0}. {1}{2}", lineindex, item.MenuName, Environment.NewLine));
                        lineindex++;
                    }

                    Console.Write(menuToPrint);
                    menuToPrint.Length = k_Zero;
                    menuToPrint.Capacity = k_Zero;
                    userChoice = this.getAndcheckInputLegality();

                    if (userChoice == k_Zero)
                    {
                        backOrExitFlag = true;
                    }
                    else
                    {
                        Console.Clear();
                        this.r_MenuItems[userChoice - k_One].ExecuteActionOrShowSubMenu();
                    }
                }
                while (!backOrExitFlag);

                Console.Clear();
            }
        }

        private int getAndcheckInputLegality()
        {
            bool status = false;
            int result = -1;
            Console.WriteLine("Please input your numeric choice in the following range: {0} - {1}", k_Zero, this.r_MenuItems.Count);
            string input = Console.ReadLine();
            do
            {
                if (input.Length == k_One && int.TryParse(input, out result) && result >= k_Zero && result <= r_MenuItems.Count)
                {
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", k_Zero, this.r_MenuItems.Count);
                    input = Console.ReadLine();
                }
            }
            while (!status);
            return result;
        }
    }
}