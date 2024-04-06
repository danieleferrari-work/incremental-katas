using System.Text.RegularExpressions;

namespace EvilCorp;

public class Censor
{
    private readonly string[] blacklist;

    public Censor(string[] blacklistedWords)
    {
        this.blacklist = blacklistedWords;
    }

    public string ApplyCensorship(string inputString)
    {
        var result = inputString;

        var inputArray = inputString.Split(' ');
        var resultArray = inputArray;

        for (int i = 0; i < inputArray.Length; i++)
        {
            foreach (var blacklistedWord in blacklist)
            {
                if (inputArray[i].Contains(blacklistedWord))
                {
                    var regex = new Regex("[a-zA-Z0-9]");

                    resultArray[i] = regex.Replace(inputArray[i], "X");
                }
            }
        }

        return String.Join(" ", resultArray);
    }
}