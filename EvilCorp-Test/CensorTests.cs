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
    public void ApplyCensorship_ShouldWork(string[] blacklistedWords, string inputString, string expectedResult)
    {
        var censor = new Censor(blacklistedWords);

        var result = censor.ApplyCensorship(inputString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

}
