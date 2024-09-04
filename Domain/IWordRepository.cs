namespace Domain;

public interface IWordRepository
{
    IEnumerable<string> GetAll();
}
