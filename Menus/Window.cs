namespace SlipstreamEngine.Menus;
public partial class Window : Form
{
    public Window()
    {
        InitializeComponent();
        this.Resize += resize;
    }

    #region Writing
    public void Write(string str)
    {
        this.console.AppendText(str);
        this.Refresh();
    }

    public void WriteLine(string str)
    {
        Write($"{str}\n");
    }
    #endregion
    
    // Clears the console
    public void Clear() => this.console.Clear();
    public void center()
    {
        // Selects all the text and aligns it to the center
        this.console.SelectAll();
        this.console.SelectionAlignment = HorizontalAlignment.Center;
        this.console.DeselectAll();
    }

    // Clears the current 
    public void changeString(string str)
    {
        Clear();
        WriteLine(str);
    }

    // Returns the console
    public RichTextBox getConsole() => this.console;

    // Change the font size of the window
    public void fontSize(float size) => this.console.Font = new Font("Consolas", size);

    // Called to make sure the text box fills the window at all times
    private void resize(object sender, EventArgs e) => this.console.Size = this.Size;
}
