
using System.Text.RegularExpressions;

namespace EvilCorp;

public class Replacer
{
    private string[] blacklistedWords;
    private string[] replacementWords;

    public Replacer(string[] blacklistedWords, string[] replacementWords)
    {
        this.blacklistedWords = blacklistedWords;
        this.replacementWords = replacementWords;
    }

    public string ApplyCensorship(string inputString)
    {
        var inputArray = inputString.Split(' ');
        var resultArray = (string[])inputArray.Clone();

        for (int i = 0; i < inputArray.Length; i++)
        {
            for (int j = 0; j < blacklistedWords.Length; j++)
            {
                string? blacklistedWord = blacklistedWords[j];
                if (inputArray[i].Contains(blacklistedWord, StringComparison.OrdinalIgnoreCase))
                {
                    var regex = new Regex("[a-zA-Z0-9]+");
                    resultArray[i] = regex.Replace(inputArray[i], replacementWords[j]);

                    var isFirstCharUpperCase = Char.IsUpper(inputArray[i].First());
                    if (isFirstCharUpperCase)
                        resultArray[i] = resultArray[i].Insert(0, resultArray[i].First().ToString().ToUpper()).Remove(1, 1);
                }
            }
        }

        return String.Join(" ", resultArray);
    }
}