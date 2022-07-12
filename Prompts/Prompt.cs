namespace SlipstreamEngine.Prompts;
public class Prompt
{
    // The actual question prompted to youu
    public string text { get; private set; }
    // The list of possible answers
    public List<string> answers { get; private set; }

    public Prompt(string text, List<string> answers)
    {
        this.text = text;
        this.answers = answers;
    }
    public string getFullString()
    {
        string answersFullString = string.Empty;
        // Adds each possible answer together with the index
        foreach (string answer in answers)
        {
            int index = this.answers.IndexOf(answer) + 1;
            answersFullString += index.ToString() + ": " + answer + "\n";
        }
        // Returns one long string with a line break after the question and each answer
        return text + "\n" + answersFullString;
    }

}
