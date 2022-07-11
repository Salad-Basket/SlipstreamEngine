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
        public string getFullString()
        {
            string fullString = string.Empty;
            foreach (string answer in answers)
            {
                int index = this.answers.IndexOf(answer) + 1;
                fullString += index.ToString() + ": " + answer + "\n";
            }
            return text + "\n" + fullString;
        }

    }
}
