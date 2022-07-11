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
        
    public void Clear() => this.console.Clear();
    public void center()
    {
        // Selects all the text and aligns it to the center
        this.console.SelectAll();
        this.console.SelectionAlignment = HorizontalAlignment.Center;
        this.console.DeselectAll();
    }

    // Called to make sure the text box fills the window at all times
    private void resize(object sender, EventArgs e) => this.console.Size = this.Size;
}
