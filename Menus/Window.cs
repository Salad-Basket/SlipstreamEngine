namespace SlipstreamEngine.Menus;
public partial class Window : Form
{
    public Window()
    {
        InitializeComponent();
        this.Resize += _Resize;
    }

    #region Writing
    /// <include file='./xml/Window.xml' path='Window/Methods/Write' />
    public void Write(string str)
    {
        this.console.AppendText(str);
        this.Refresh();
    }
    /// <include file='./xml/Window.xml' path='Window/Methods/WriteLine' />
    public void WriteLine(string str)
    {
        Write($"{str}\n");
    }
    #endregion

    /// <include file='./xml/Window.xml' path='Window/Methods/Clear' />
    public void Clear() => this.console.Clear();

    /// <include file='./xml/Window.xml' path='Window/Methods/Center' />
    public void Center()
    {
        // Selects all the text and aligns it to the center
        this.console.SelectAll();
        this.console.SelectionAlignment = HorizontalAlignment.Center;
        this.console.DeselectAll();
    }

    /// <include file='./xml/Window.xml' path='Window/Methods/ChangeString' />
    public void ChangeString(string str)
    {
        Clear();
        WriteLine(str);
    }

    /// <include file='./xml/Window.xml' path='Window/Methods/GetConsole' />
    public RichTextBox GetConsole() => this.console;

    /// <include file='./xml/Window.xml' path='Window/Methods/FontSize' />
    public void FontSize(float size) => this.console.Font = new Font("Consolas", size);

    // Called to make sure the text box fills the window at all times
    private void _Resize(object? sender, EventArgs e) => this.console.Size = this.Size;
}
