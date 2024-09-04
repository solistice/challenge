namespace Domain.ValueObjects;

public class Match : ValueObject
{
    public List<string> MatchedWords { get; }

    public static Match Create(List<string> matchedWords)
    {
        if (matchedWords.Count < 2)
            throw new ArgumentOutOfRangeException(nameof(matchedWords), "A match should contain at least two different words");

        return new Match(matchedWords);
    }
    public override string ToString()
    => $"{string.Join("+", MatchedWords)} = {string.Join(string.Empty, MatchedWords)}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var value in MatchedWords)
            yield return value;
    }

    private Match(List<string> matchedWords) => MatchedWords = new List<string>(matchedWords);
}
