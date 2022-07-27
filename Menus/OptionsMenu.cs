using SlipstreamEngine.Prompts;

namespace SlipstreamEngine.Menus;
public class OptionsMenu
{
    public Window window { get; private set; }
    public MainMenu? menu { get; private set; } = null;
    public Action? playAction { get; private set; }
    public Prompt prompt { get; private set; } = new Prompt(new List<string>() { "Font Size" }, "Options Menu:");
    private InputManager.InputManager im = InputManager.InputManager.GetInstance;
    private Action? pauseAction;
    private string? previousString;

    public OptionsMenu(Window window)
    {
        this.window = window;
    }

    public OptionsMenu(Window window, MainMenu menu, Action playAction)
    {
        this.window = window;
        this.menu = menu;
        this.playAction = playAction;
    }

    public void DisplayMenu(Action? pauseAction = null, int pauseIndex = 0)
    {
        this.previousString = this.window.GetConsole().Text;
        this.pauseAction = pauseAction;
        im.RemoveAction(pauseIndex);
        this.window.ChangeString(GetMenu());
    }

    public string GetMenu() => prompt.GetFullString() + "Esc.) Quit";

    public Action OptionInput() => () =>
    {
        InputManager.InputManager im = InputManager.InputManager.GetInstance;
        int optionIndex = im.actions.Count - 1;
        switch (im.CheckKey(im.Key))
        {
            case 1:
                {
                    im.SwitchAction(optionIndex, FontControl());
                    this.window.ChangeString("Font Size: " + this.window.GetConsole().Font.Size + "\nEsc: Exit");
                    break;
                }
            case 2:
            case -2:
                {
                    im.RemoveAction(optionIndex);
                    if (menu != null) this.menu.DisplayMenu(this.window, this.playAction);
                    else { this.window.ChangeString(previousString); im.AddAction(this.pauseAction); }
                    break;
                }
        }
    };

    private Action FontControl() => () =>
    {
        InputManager.InputManager im = InputManager.InputManager.GetInstance;
        int fontIndex = im.actions.Count - 1;
        switch (im.CheckKey(im.Key))
        {
            case 10:
                {
                    this.window.FontSize(this.window.GetConsole().Font.Size + 1f);
                    this.window.ChangeString("Font Size: " + this.window.GetConsole().Font.Size + "\nEsc: Exit");
                    break;
                }
            case 11:
                {
                    this.window.FontSize(this.window.GetConsole().Font.Size - 1f);
                    this.window.ChangeString("Font Size: " + this.window.GetConsole().Font.Size + "\nEsc: Exit");
                    break;
                }
            case -2:
                {
                    im.SwitchAction(fontIndex, OptionInput());
                    this.window.ChangeString(GetMenu());
                    break;
                }
            default: break;
        }
    };
}
