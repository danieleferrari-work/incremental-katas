using System.Collections.Generic;
using NUnit.Framework;
using EvilCorp;

namespace EvilCorp_Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(new string[] { }, "You are a nice person", "You are a nice person")]
    [TestCase(new string[] { "nice" }, "You are a nice person", "You are a XXXX person")]
    [TestCase(new string[] { "nice" }, "You are a nice nice person", "You are a XXXX XXXX person")]
    [TestCase(new string[] { "are" }, "You are a nice person", "You XXX a nice person")]
    [TestCase(new string[] { "nice", "pony", "sun", "light", "fun", "happy", "funny", "joy" }, 
                            "Such a nice day with a bright sun, makes me happy", 
                            "Such a XXXX day with a bright XXX, makes me XXXXX")]
    public void ApplyCensorship_ShouldWork(string[] blacklistedWords, string inputString, string expectedResult)
    {
        var censor = new Censor(blacklistedWords);

        var result = censor.ApplyCensorship(inputString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

}
