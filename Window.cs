using System.Windows.Forms;

namespace SlipstreamEngine
{
    public class Window : Form
    {
        Form form;
        RichTextBox console;
        
        public Window()
        {
            form = new Form();
            console = new RichTextBox();

            this.Controls.Add(console);
            this.Resize += Window_Resize;
            Window_Load(console);
        }

        private void Window_Load(RichTextBox console)
        {
            console.Size = this.ClientSize;
            console.Top = 0;
            console.Left = 0;
            console.BackColor = Color.Black;
            console.ForeColor = Color.White;
            console.WordWrap = false;
            console.Font = new Font("Consolas", 12);
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            console.Size = this.ClientSize;
        }

    }
}