using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EvilCorp_Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NoBlacklistedWords_ShouldReturnInputString()
    {
        var blacklistedWords = new List<string>();
        var censor = new Censor(blacklistedWords);
        var inputString = "You are a nice person";

        var result = censor.ApplyCensorship(inputString);

        var expectedResult = "You are a nice person";
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void NiceIsBlacklisted_ShouldCensorNiceFromInputString()
    {
        var blacklistedWords = new List<string>() { "nice" };
        var censor = new Censor(blacklistedWords);
        var inputString = "You are a nice person";

        var result = censor.ApplyCensorship(inputString);

        var expectedResult = "You are a XXXX person";
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void NiceIsBlacklisted_ShouldCensorNiceFromInputString_WhenInputHas2Occurences()
    {
        var blacklistedWords = new List<string>() { "nice" };
        var censor = new Censor(blacklistedWords);
        var inputString = "You are a nice nice person";

        var result = censor.ApplyCensorship(inputString);

        var expectedResult = "You are a XXXX XXXX person";
        Assert.That(result, Is.EqualTo(expectedResult));
    }

}

public class Censor
{
    private readonly List<string> blacklistedWords;

    public Censor(List<string> blacklistedWords)
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