namespace SlipstreamEngine.Menus;
public partial class Window : Form
{
    public Window()
    {
        InitializeComponent();
        this.Resize += resize;
    }

    #region Writing
    /// <summary> Writes to the console </summary>
    public void Write(string str)
    {
        this.console.AppendText(str);
        this.Refresh();
    }
    /// <summary> Writes to the console and appends a line break character </summary>
    public void WriteLine(string str)
    {
        Write($"{str}\n");
    }
    #endregion

    /// <summary> Clears the console </summary>
    public void Clear() => this.console.Clear();
    /// <summary> Centers all text on screen </summary>
    public void center()
    {
        // Selects all the text and aligns it to the center
        this.console.SelectAll();
        this.console.SelectionAlignment = HorizontalAlignment.Center;
        this.console.DeselectAll();
    }

    /// <summary> Replaces the string on screen with the string given </summary>
    public void changeString(string str)
    {
        Clear();
        WriteLine(str);
    }

    /// <summary> Returns the console object </summary>
    /// <returns> RichTextBox </returns>
    public RichTextBox getConsole() => this.console;

    /// <summary> Change the font size of the window </summary>
    public void fontSize(float size) => this.console.Font = new Font("Consolas", size);

    // Called to make sure the text box fills the window at all times
    private void resize(object? sender, EventArgs e) => this.console.Size = this.Size;
}
