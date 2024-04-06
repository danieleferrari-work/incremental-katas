using NUnit.Framework;
using EvilCorp;

namespace EvilCorp_Test;

public class ReplacerTests
{

    [TestCase(new string[] { "bad", "better", "objection", "agree" },
              new string[] { "ungood", "gooder", "thoughtcrime", "crimestop" },
              "Objection is bad, a better thing to do, is to agree.",
              "Thoughtcrime is ungood, a gooder thing to do, is to crimestop.")]

    public void ApplyCensorship_ShouldWork(string[] blacklistedWords, string[] replacementWords, string inputString, string expectedResult)
    {
        var censor = new Replacer(blacklistedWords, replacementWords);

        var result = censor.ApplyCensorship(inputString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}



