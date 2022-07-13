using SlipstreamEngine.Menus;

namespace SlipstreamEngine.InputManager;
public sealed class InputManager
{
    /// <include file='InputManager.xml' path='InputManager/Variables/window'/>
    public Window window { get; private set; }

    /// <include file='InputManager.xml' path='InputManager/Variables/actions'/>
    public List<Action> actions { get; private set; } = new List<Action>();

    /// <include file='InputManager.xml' path='InputManager/Variables/key'/>
    public Keys Key { get; private set; }

    private static InputManager? instance = null;

    /// <include file='InputManager.xml' path='InputManager/Variables/GetInstance'/>
    public static InputManager GetInstance
    {
        get
        {
            if (instance == null)
                instance = new InputManager();
            return instance;
        }
    }

    private InputManager() { this.window = new Window(); }

    /// <include file='InputManager.xml' path='InputManager/Methods/SetWindow'/>
    public void SetWindow(Window window)
    {
        this.window = window;
        this.window.getConsole().KeyDown += KeyDown;
    }

    /// <include file='InputManager.xml' path='InputManager/Methods/AddAction'/>
    public void AddAction(Action action) => this.actions.Add(action);

    /// <include file='InputManager.xml' path='InputManager/Methods/RemoveAction'/>
    public void RemoveAction(int index) => this.actions.RemoveAt(index);

    /// <include file='InputManager.xml' path='InputManager/Methods/SwitchAction'/>
    public void SwitchAction(int index, Action action)
    {
        RemoveAction(index);
        AddAction(action);
    }

    /// <include file='InputManager.xml' path='InputManager/Methods/CheckKey'/>
    public int CheckKey(Keys key)
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

    private void KeyDown(object? sender, KeyEventArgs e)
    {
        this.Key = e.KeyCode;
        if (actions != null) foreach (Action action in actions.ToList()) action.Invoke();
    }
}
