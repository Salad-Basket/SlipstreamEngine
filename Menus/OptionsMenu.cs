using SlipstreamEngine.Prompts;

namespace SlipstreamEngine.Menus;
public class OptionsMenu
{
    Window window;
    Prompt prompt = new Prompt("Options Menu:", new List<string>() { "Font Size" });
    public OptionsMenu(Window window)
    {
        this.window = window;
    }

    public string getMenu()
    {
        return prompt.getFullString();
    }

    public Action optionInput() => () =>
    {
        SlipstreamEngine.InputManager.InputManager im = SlipstreamEngine.InputManager.InputManager.GetInstance;
        int optionIndex = im.actions.Count - 1;
        switch(im.checkKey(im.key))
        {
            case 1:
                {
                    im.addAction(fontControl());
                    im.removeAction(optionIndex);
                    break;
                }
        }
    };

    private Action fontControl() => () =>
    {
        SlipstreamEngine.InputManager.InputManager im = SlipstreamEngine.InputManager.InputManager.GetInstance;
        int fontIndex = im.actions.Count - 1;
        switch(im.checkKey(im.key))
        {
            case 10:
                {
                    this.window.fontSize(this.window.getConsole().Font.Size + 1f);
                    break;
                }
            case 11:
                {
                    this.window.fontSize(this.window.getConsole().Font.Size - 1f);
                    break;
                }
            default: break;
        }
    };
}
