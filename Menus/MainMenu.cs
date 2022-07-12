namespace SlipstreamEngine.Menus;
public class MainMenu
{
    // Should an options menu be avaliable
    public bool optionsMenu { get; private set; }
    // Well... its the name of the game
    public string gameName { get; private set; }
    // Is the menu centered
    public bool centered { get; private set; }
    private SlipstreamEngine.InputManager.InputManager im = SlipstreamEngine.InputManager.InputManager.GetInstance;

    public MainMenu(string gameName, bool optionsMenu = false, bool centered = true)
    {
        this.optionsMenu = optionsMenu;
        this.gameName = gameName;
    }

    // Displays the menu to the window and waits for a response
    public void displayMenu(Window window, Action action)
    {
        string fullMenu = string.Empty;
        string options;
        if (optionsMenu) options = "1.) Play\n2.) Options\nEsc.) Quit";
        else options = "1.) Play\nEsc.) Quit";
        fullMenu += this.gameName;
        fullMenu += "\n" + options;

        window.Write(fullMenu);
        this.im.addAction(menuInput(window));
    }

    private Action menuInput(Window window) => () =>
    {
        int keyCode = this.im.checkKey(this.im.key);

        if (keyCode == 1) window.Write("Played");
        if (keyCode == 2 && optionsMenu) window.Write("OPTIONS!");
        else if (keyCode == 2 && !optionsMenu) Application.Exit();
        if (keyCode == -2) Application.Exit();
    };
}
