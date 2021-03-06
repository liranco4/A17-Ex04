﻿namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_MenuHeaderName = string.Empty;

        public MenuItem(string i_MenuName)
        {
            this.m_MenuHeaderName = i_MenuName;
        }

        public string MenuName
        {
            get { return this.m_MenuHeaderName; }
        }

        internal abstract void ExecuteActionOrShowSubMenu();
    }
}