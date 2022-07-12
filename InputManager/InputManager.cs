using SlipstreamEngine.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlipstreamEngine.InputManager
{
    public sealed class InputManager
    {
        Window window;
        public List<Action> actions { get; private set; } = new List<Action>();
        public Keys key { get; private set; }

        private static InputManager instance = null;
        public static InputManager GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        private InputManager()
        {
        }

        public bool setWindow(Window window)
        {
            this.window = window;
            this.window.getConsole().KeyDown += KeyDown;
            return true;
        }

        public bool addAction(Action action)
        {
            this.actions.Add(action);
            return true;
        }

        public void removeAction(int index) => this.actions.RemoveAt(index);

        public void KeyDown(object sender, KeyEventArgs e)
        {
            this.key = e.KeyCode;
            if (actions != null) foreach (Action action in actions.ToList()) action.Invoke();
        }
    
        public int checkKey(Keys key)
        {
            string keyStr = key.ToString();
            switch (keyStr)
            {
                case "D0":
                case "NumPad0": return 0;
                case "D1":
                case "NumPad1": return 1;
                case "D2":
                case "NumPad2": return 2;
                case "D3":
                case "NumPad3": return 3;
                case "D4":
                case "NumPad4": return 4;
                case "D5":
                case "NumPad5": return 5;
                case "D6":
                case "NumPad6": return 6;
                case "D7":
                case "NumPad7": return 7;
                case "D8":
                case "NumPad8": return 8;
                case "D9":
                case "NumPad9": return 9;
                case "Escape": return -2;
                case "Up": return 10;
                case "Down": return 11;
                default: return -1;
            }
        }
    }
}
