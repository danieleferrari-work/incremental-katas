using System.Collections.Generic;

namespace EvilCorp;

public class Censor
{
    private readonly string[] blacklistedWords;

    public Censor(string[] blacklistedWords)
    {
        this.blacklistedWords = blacklistedWords;
    }

    public string ApplyCensorship(string inputString)
    {
        var result = inputString;

        foreach (var word in blacklistedWords)
        {
            result = result.Replace(word, "XXXX");
        }

        return result;
    }
}