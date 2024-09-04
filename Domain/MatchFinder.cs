using Domain.ValueObjects;

namespace Domain;

public class MatchFinder
{
    public static MatchFinder Create(int length, int maxCombinations)
    {
        var targetLength = TargetLength.Create(length);
        var maxCombinationLength = MaxCombinationLength.Create(maxCombinations);

        return new MatchFinder(targetLength, maxCombinationLength);
    }

    public List<Match> FindAllMatches(IEnumerable<string> words)
    {
        var allMatches = new List<Match>();
        var possiblePrefixes = words.Where(word => word.Length < _targetLength.Value);
        var targetLengthWords = words
            .Where(word => word.Length == _targetLength.Value);

        _prefixTree.Populate(possiblePrefixes);

        foreach (var word in targetLengthWords)
        {
            if (_prefixTree.TryGetCombination(word, out var matches))
                allMatches.AddRange(matches);
        }

        return allMatches;
    }

    private readonly TargetLength _targetLength;
    private readonly PrefixTree _prefixTree;

    private MatchFinder(TargetLength targetLength, MaxCombinationLength maxCombinations)
    {
        _targetLength = targetLength;
        _prefixTree = PrefixTree.Create(maxCombinations);
    }
}
