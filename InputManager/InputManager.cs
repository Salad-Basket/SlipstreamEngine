using SlipstreamEngine.Menus;

namespace SlipstreamEngine.InputManager;
public sealed class InputManager
{
    /// <include file='./xml/InputManager.xml' path='InputManager/Variables/window'/>
    public Window window { get; private set; }

    /// <include file='./xml/InputManager.xml' path='InputManager/Variables/actions'/>
    public List<Action> actions { get; private set; } = new List<Action>();

    /// <include file='./xml/InputManager.xml' path='InputManager/Variables/key'/>
    public Keys Key { get; private set; }

    private static InputManager? instance = null;

    /// <include file='./xml/InputManager.xml' path='InputManager/Variables/GetInstance'/>
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

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/SetWindow'/>
    public void SetWindow(Window window)
    {
        this.window = window;
        this.window.GetConsole().KeyDown += KeyDown;
    }

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/AddAction'/>
    public void AddAction(Action action) => this.actions.Add(action);

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/RemoveAction'/>
    public void RemoveAction(int index) => this.actions.RemoveAt(index);

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/SwitchAction'/>
    public void SwitchAction(int index, Action action)
    {
        RemoveAction(index);
        AddAction(action);
    }

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/ClearActions'/>
    public void ClearActions() => this.actions.Clear();

    /// <include file='./xml/InputManager.xml' path='InputManager/Methods/CheckKey'/>
    public int CheckKey(Keys key)
    {
        string keyStr = key.ToString();
        char toParse = keyStr[^1];
        if (Char.GetNumericValue(toParse) < 10 && Char.GetNumericValue(toParse) >= 0) return Convert.ToInt16(Char.GetNumericValue(toParse));
        switch (keyStr)
        {
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
