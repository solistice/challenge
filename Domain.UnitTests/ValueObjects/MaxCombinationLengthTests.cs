using Domain.ValueObjects;
using FluentAssertions;

namespace DomainUnitTests.ValueObjects;

[TestFixture]
internal class MaxCombinationLengthTests
{
    [Test]
    public void CreateMaxCombinationLength_WithValidLength_ShouldSucceed()
    {
        // Act
        var maxCombinationLength = MaxCombinationLength.Create(3);

        // Assert
        maxCombinationLength.Should().NotBeNull();
        maxCombinationLength.Value.Should().Be(3);
    }

    [Test]
    public void CreateMaxCombinationLength_WithInvalidLength_ShouldThrow()
    {
        // Act
        Action act = () => MaxCombinationLength.Create(0);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("MaxCombinationLength should at least be 2 to make sense (Parameter 'value')");
    }
}
