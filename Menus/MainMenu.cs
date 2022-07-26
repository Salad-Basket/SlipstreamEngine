namespace SlipstreamEngine.Menus;
/// <include file='./xml/Menus.xml' path='Menus/MainMenu/Methods/MainMenu[@name="MainMenu"]/*' />
public class MainMenu
{
    /// <include file='./xml/Menus.xml' path="Menus/MainMenu/Variables/MainMenu[@name='gameName']/*" />
    public string gameName { get; private set; }
    /// <include file='./xml/Menus.xml' path="Menus/MainMenu/Variables/MainMenu[@name='optionsMenu']/*" />
    public bool optionsMenu { get; private set; }
    /// <include file='./xml/Menus.xml' path="Menus/MainMenu/Variables/MainMenu[@name='centered']/*" />
    public bool centered { get; private set; }
    /// <include file='./xml/Menus.xml' path="Menus/MainMenu/Variables/MainMenu[@name='playAction']/*" />
    public Action playAction { get; private set; }
    private int menuIndex;
    private SlipstreamEngine.InputManager.InputManager im = SlipstreamEngine.InputManager.InputManager.GetInstance;

    /// <include file='./xml/Menus.xml' path='Menus/MainMenu/Methods/MainMenu[@name="MainMenu"]/*' />
    public MainMenu(string gameName, bool centered = true, bool optionsMenu = false)
    {
        this.optionsMenu = optionsMenu;
        this.gameName = gameName;
        this.centered = centered;
        this.playAction = () => { };
    }

    /// <include file='./xml/Menus.xml' path='Menus/MainMenu/Methods/MainMenu[@name="DisplayMenu"]/*' />
    public void DisplayMenu(Window window, Action playAction)
    {
        string fullMenu = string.Empty;
        string options;
        if (optionsMenu) options = "1.) Play\n2.) Options\nEsc.) Quit";
        else options = "1.) Play\nEsc.) Quit";
        fullMenu += this.gameName;
        fullMenu += "\n" + options;

        this.im.AddAction(menuInput(window, playAction));
        this.menuIndex = this.im.actions.Count - 1;
        window.Clear();
        window.Write(fullMenu);
        if (this.centered) window.Center();
    }

    private Action menuInput(Window window, Action playAction) => () =>
    {
        int keyCode = this.im.CheckKey(this.im.Key);

        if (keyCode == 1) playAction.Invoke();
        if (keyCode == 2 && optionsMenu)
        {
            OptionsMenu options = new OptionsMenu(window, this, playAction);
            window.ChangeString(options.GetMenu());
            im.SwitchAction(menuIndex, options.OptionInput());
        }
        else if (keyCode == 2 && !optionsMenu) Application.Exit();
        else if (keyCode == 3 && optionsMenu) Application.Exit();
        if (keyCode == -2) Application.Exit();
    };
}
