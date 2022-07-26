namespace SlipstreamEngine.Prompts;
public class Prompt
{
    // The actual question prompted to you
    public string text { get; private set; }
    // The list of possible answers
    public List<string> answers { get; private set; }

    public Prompt() 
    {
        this.text = "Undefined prompt text";
        if (this.answers != null) answers.Clear();
    }

    public Prompt(List<string> answers, string text = "Undefined prompt text")
    {
        this.text = text;
        this.answers = answers;
    }

    public void AddAnswer(string str) => answers.Add(str);
    public void SetText(string str) => text = str;
    
    public string GetFullString()
    {
        string answersFullString = string.Empty;
        // Adds each possible answer together with the index
        foreach (string answer in answers)
        {
            int index = this.answers.IndexOf(answer) + 1;
            answersFullString += index.ToString() + ": " + answer + "\n";
        }
        // Returns the full string ready to be written to the console
        return text + "\n" + answersFullString;
    }

}
