using Domain.ValueObjects;
using FluentAssertions;

namespace Domain.UnitTests;

[TestFixture]
public class MatchFinderTests
{
    private readonly List<string> _randomWords = ["foo", "bar", "fo", "ob", "ar", "kee", "ke", "nze", "foobar", "kenze", "keenze"];
    private readonly MaxCombinationLength _validMaxCombinationLength = MaxCombinationLength.Create(3);

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void CreateMatchFinder_WithMultipleMatches_ShouldSucceed()
    {
        // Arrange
        var matchFinder = MatchFinder.Create(6, 6);
        var expectedMatches = new HashSet<Match>(
           [Match.Create(["fo", "ob", "ar"]), 
            Match.Create(["foo", "bar"]),
            Match.Create(["kee", "nze"])]);

        // Act
        var matches = matchFinder.FindAllMatches(_randomWords);

        // Assert
        matches.Count.Should().Be(3);
        foreach (var match in matches)
            expectedMatches.Contains(match).Should().BeTrue();
    }

    [Test]
    public void CreateMatchFinder_WithMultipleMatches_ButLimitingCombinations_ShouldSucceed()
    {
        // Arrange
        var matchFinder = MatchFinder.Create(6, 2);
        var expectedMatches = new HashSet<Match>(
           [Match.Create(["foo", "bar"]),
            Match.Create(["kee", "nze"])]);

        // Act
        var matches = matchFinder.FindAllMatches(_randomWords);

        // Assert
        matches.Count.Should().Be(2);
        foreach (var match in matches)
            expectedMatches.Contains(match).Should().BeTrue();
    }

    [Test]
    public void CreateMatchFinder_WithMultipleMatches_ButLimitingLength_ShouldSucceed()
    {
        // Arrange
        var matchFinder = MatchFinder.Create(5, 6);
        var expectedMatches = new HashSet<Match>([Match.Create(["ke", "nze"])]);

        // Act
        var matches = matchFinder.FindAllMatches(_randomWords);

        // Assert
        matches.Count.Should().Be(1);
        foreach (var match in matches)
            expectedMatches.Contains(match).Should().BeTrue();
    }
}