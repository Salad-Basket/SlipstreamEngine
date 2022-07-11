using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlipstreamEngine
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            this.Resize += resize;
        }

        public void Write(string str)
        {
            this.console.AppendText(str);
        }

        public void WriteLine(string str)
        {
            Write($"{str}\n");
        }

        private void resize(object sender, EventArgs e)
        {
            this.console.Size = this.Size;
        }
    }
}
