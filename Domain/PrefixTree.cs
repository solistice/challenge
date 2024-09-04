
using Domain.ValueObjects;

namespace Domain;

internal class PrefixTree
{
    public static PrefixTree Create(MaxCombinationLength maxCombinationLength)
        => new(maxCombinationLength);

    public void Populate(IEnumerable<string> prefixes)
    {
        foreach (var word in prefixes)
            Insert(word);
    }

    public bool TryGetCombination(string word, out List<Match> matches)
    {
        matches = [];
        TraverseTree(word, [], matches);
        return matches.Count > 0;
    }

    private bool TraverseTree(string word, List<string> wordPath, List<Match> matches)
    {
        if (wordPath.Count > _maxCombinationLength.Value) return false;
        if (word.Length == 0) return true;

        var currentNode = _root;
        for (var i = 0; i < word.Length; ++i)
        {
            var c = word[i];
            if (!currentNode.Children.TryGetValue(c, out var childNode))
            {
                return false;
            }

            currentNode = childNode;
            if (currentNode.EndOfWord)
            {
                wordPath.Add(word.Substring(0, i + 1));
                if (TraverseTree(word.Substring(i + 1), wordPath, matches))
                    matches.Add(Match.Create(wordPath));

                wordPath.RemoveAt(wordPath.Count - 1);
            }
        }

        return false;
    }

    private readonly PrefixTreeNode _root;
    private readonly MaxCombinationLength _maxCombinationLength;

    private PrefixTree(MaxCombinationLength maxCombinationLength)
    {
        _root = new PrefixTreeNode();
        _maxCombinationLength = maxCombinationLength;
    }

    private void Insert(string word)
    {
        var current = _root;
        foreach (var character in word)
        {
            if (!current.Children.TryGetValue(character, out var value))
            {
                current.Children[character] = new PrefixTreeNode();
            }

            current = current.Children[character];
        }

        current.EndOfWord = true;
    }

    internal class PrefixTreeNode
    {
        public Dictionary<char, PrefixTreeNode> Children { get; private set; }

        public bool EndOfWord { get; set; }

        public PrefixTreeNode()
        {
            Children = [];
            EndOfWord = false;
        }
    }
}
