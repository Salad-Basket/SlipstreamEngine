using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlipstreamEngine.Prompts
{
    public class Prompt
    {
        public string text { get { return text; } set { text = value; } }
        public List<string> answers { get { return answers; } set { answers = value; } }

        public Prompt(string text, List<string> answers)
        {
            this.text = text;
            this.answers = answers;
        }

    }
}
