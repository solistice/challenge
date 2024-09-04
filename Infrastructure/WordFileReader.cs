using Application;
using Domain;

namespace Infrastructure;

public class WordFileReader : IWordRepository

{
    private readonly string _filePath;

    public WordFileReader(ChallengeOptions options)
    {
        _filePath = options.FilePath;
    }

    public IEnumerable<string> GetAll()
    {
        var wordArray = File.ReadAllLines(_filePath);
        return new List<string>(wordArray);
    }
}
