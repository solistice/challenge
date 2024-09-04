using Domain.ValueObjects;
using MediatR;

namespace Application.Queries;

public record FindAllMatchesQuery(int WordLength, int MaximumNumberOfConcatenations) : IRequest<List<Match>>;
