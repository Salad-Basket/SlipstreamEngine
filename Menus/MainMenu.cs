namespace SlipstreamEngine.Menus;
public class MainMenu
{
    // Should an options menu be avaliable
    public bool optionsMenu { get; private set; }
    // Well... its the name of the game
    public string gameName { get; private set; }
    // Is the menu centered
    public bool centered { get; private set; }
    public Action playAction { get; private set; }
    private int menuIndex;
    private SlipstreamEngine.InputManager.InputManager im = SlipstreamEngine.InputManager.InputManager.GetInstance;

    public MainMenu(string gameName, bool centered = true, bool optionsMenu = false)
    {
        this.optionsMenu = optionsMenu;
        this.gameName = gameName;
        this.centered = centered;
    }

    // Displays the menu to the window and waits for a response
    public void displayMenu(Window window, Action playAction)
    {
        string fullMenu = string.Empty;
        string options;
        if (optionsMenu) options = "1.) Play\n2.) Options\nEsc.) Quit";
        else options = "1.) Play\nEsc.) Quit";
        fullMenu += this.gameName;
        fullMenu += "\n" + options;

        this.im.addAction(menuInput(window, playAction));
        this.menuIndex = this.im.actions.Count - 1;
        window.Clear();
        window.Write(fullMenu);
        if (this.centered) window.center();
    }

    private Action menuInput(Window window, Action playAction) => () =>
    {
        int keyCode = this.im.checkKey(this.im.key);

        if (keyCode == 1) playAction.Invoke();
        if (keyCode == 2 && optionsMenu)
        {
            OptionsMenu options = new OptionsMenu(window, this, playAction);
            window.changeString(options.getMenu());
            im.switchAction(menuIndex, options.optionInput());
        }
        else if (keyCode == 2 && !optionsMenu) Application.Exit();
        else if (keyCode == 3 && optionsMenu) Application.Exit();
        if (keyCode == -2) Application.Exit();
    };
}
