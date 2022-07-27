﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlipstreamEngine.Menus
{
    /// <include file='./xml/PauseMenu.xml' path='PauseMenu/Methods/PauseMenu'/>
    public class PauseMenu
    {
        private readonly bool optionsMenu;
        InputManager.InputManager im = InputManager.InputManager.GetInstance;
        private readonly List<Action> actions;
        private int actionIndex;
        private Window window;
        private string previousString;
        private readonly bool centered;

        /// <include file='./xml/PauseMenu.xml' path='PauseMenu/Methods/PauseMenu'/>
        public PauseMenu(Window window, List<Action> actions, bool centered = true, bool optionsMenu = false)
        {
            this.window = window;
            this.optionsMenu = optionsMenu;
            this.centered = centered;

            this.actions = actions;
        }

        /// <include file='./xml/PauseMenu.xml' path='PauseMenu/Methods/DisplayMenu'/>
        public void DisplayMenu()
        {
            previousString = this.window.GetConsole().Text;
            window.ChangeString(GetOptionsMenu());
            im.ClearActions();
            im.AddAction(MenuHandling());
            actionIndex = im.actions.Count - 1;
        }

        private string GetOptionsMenu()
        {
            if (optionsMenu) return "1.) Resume\n2.) Options\n 3.)Exit";
            return "1.) Resume\n 2.) Exit";
        }

        private Action MenuHandling()
        {
            return () =>
            {
                switch(im.CheckKey(im.Key))
                {
                    case (1):
                    case (-2):
                        im.RemoveAction(actionIndex);
                        foreach (Action action in actions.ToList()) im.AddAction(action);
                        this.window.ChangeString(previousString);
                        this.window.WriteLine(im.actions.Count.ToString());
                        break;
                    case (2):
                        if(optionsMenu)
                        {
                            OptionsMenu optionsMenu = new OptionsMenu(this.window);
                            optionsMenu.DisplayMenu();
                        } else Application.Exit();
                        break;
                    case(3):
                        Application.Exit();
                        break;
                }
            };
        }
    }
}
