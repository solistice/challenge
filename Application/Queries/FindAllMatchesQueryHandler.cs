using Domain;
using Domain.ValueObjects;
using MediatR;

namespace Application.Queries;

public class FindAllMatchesQueryHandler(IWordRepository wordRepository) : IRequestHandler<FindAllMatchesQuery, List<Match>>
{
    public Task<List<Match>> Handle(FindAllMatchesQuery request, CancellationToken cancellationToken)
    {
        var allWords = wordRepository.GetAll();

        var matchFinder = MatchFinder.Create(request.WordLength, request.MaximumNumberOfConcatenations);
        return Task.FromResult(matchFinder.FindAllMatches(allWords));
    }
}
