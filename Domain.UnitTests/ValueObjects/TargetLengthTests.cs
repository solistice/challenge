using Domain.ValueObjects;
using FluentAssertions;

namespace DomainUnitTests.ValueObjects;

[TestFixture]
internal class TargetLengthTests
{
    [Test]
    public void CreateTargetLength_WithValidLength_ShouldSucceed()
    {
        // Act
        var targetLength = TargetLength.Create(3);

        // Assert
        targetLength.Should().NotBeNull();
        targetLength.Value.Should().Be(3);
    }

    [Test]
    public void CreateMaxCombinationLength_WithInvalidLength_ShouldThrow()
    {
        // Act
        Action act = () => TargetLength.Create(-1);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Target length should at least be 1 to make sense (Parameter 'value')");
    }
}
