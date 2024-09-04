using Domain.ValueObjects;
using FluentAssertions;

namespace DomainUnitTests.ValueObjects;

[TestFixture]
internal class MatchTests
{
    [Test]
    public void CreateMatch_WithValidStrings_ShouldSucceed()
    {
        // Act
        var matchedWords = Match.Create(["ke", "nze"]);

        // Assert
        matchedWords.Should().NotBeNull();
        matchedWords.MatchedWords.First().Should().Be("ke");
    }

    [Test]
    public void CreateMatch_WithOneString_ShouldThrow()
    {
        // Act
        Action act = () => Match.Create(["ke"]);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("A match should contain at least two different words (Parameter 'matchedWords')");
    }
}
