namespace SlipstreamEngine.Menus;
public class MainMenu
{
    public bool optionsMenu { get; private set; }
    public string gameName { get; private set; }

    public MainMenu(string gameName, bool optionsMenu = false, bool centered = true)
    {
        this.optionsMenu = optionsMenu;
        this.gameName = gameName;
    }

    public string getMenu()
    {
        string fullMenu = string.Empty;
        string options = string.Empty;
        if (optionsMenu) options = "1.) Play\n2.) Options\n3.) Quit";
        else options = "1.) Play\n2.) Quit";
        fullMenu += this.gameName;
        fullMenu += "\n" + options;
        return fullMenu;
    }
}
