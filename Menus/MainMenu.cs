namespace SlipstreamEngine.Menus;
public class MainMenu
{
    // Should an options menu be avaliable
    public bool optionsMenu { get; private set; }
    // Well... its the name of the game
    public string gameName { get; private set; }

    public MainMenu(string gameName, bool optionsMenu = false)
    {
        this.optionsMenu = optionsMenu;
        this.gameName = gameName;
    }

    // Returns one long string with line breaks in between possible answers
    public string getMenu()
    {
        string fullMenu = string.Empty;
        string options;
        if (optionsMenu) options = "1.) Play\n2.) Options\n3.) Quit";
        else options = "1.) Play\n2.) Quit";
        fullMenu += this.gameName;
        fullMenu += "\n" + options;
        return fullMenu;
    }
}
