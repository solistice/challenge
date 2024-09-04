using Domain.ValueObjects;
using FluentAssertions;

namespace Domain.UnitTests;

[TestFixture]
public class PrefixTreeTests
{
    private readonly List<string> _randomPrefixes = ["foo", "bar", "fo", "ob", "ar", "kee", "ke", "nze"];
    private readonly MaxCombinationLength _validMaxCombinationLength = MaxCombinationLength.Create(3);

    private PrefixTree _prefixTree;

    [SetUp]
    public void Setup()
    {
        _prefixTree = PrefixTree.Create(_validMaxCombinationLength);
        _prefixTree.Populate(_randomPrefixes);
    }

    [Test]
    public void TryGetCombination_WithOneCombination_ReturnsTrue_AndCorrectMatch()
    {
        // Arrange
        var expectedMatch = Match.Create(["ke", "nze"]);

        // Act
        var result = _prefixTree.TryGetCombination("kenze", out var matches);
        var match = 

        // Assert
        result.Should().BeTrue();
        matches.Count.Should().Be(1);
        matches.First().Should().Be(expectedMatch);
    }

    [Test]
    public void TryGetCombination_WithTwoCombinations_ReturnsTrue_AndCorrectMatches()
    {
        // Arrange
        var expectedMatches = new HashSet<Match>([Match.Create(["fo", "ob", "ar"]), Match.Create(["foo", "bar"])]);

        // Act
        var result = _prefixTree.TryGetCombination("foobar", out var matches);

        // Assert
        result.Should().BeTrue();
        matches.Count.Should().Be(2);
        foreach (var match in matches)
            expectedMatches.Contains(match).Should().BeTrue();
    }

    [Test]
    public void TryGetCombination_WithNoCombination_ReturnsFalse()
    {
        // Act
        var result = _prefixTree.TryGetCombination("apple", out var matches);

        // Assert
        result.Should().BeFalse();
        matches.Count.Should().Be(0);
    }
}