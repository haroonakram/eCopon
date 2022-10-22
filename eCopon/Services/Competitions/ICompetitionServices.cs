using eCopon.Models;
using ErrorOr;

namespace eCopon.Services.Competitions;

public interface ICompetitionServices
{
    ErrorOr<Created> CreateCompetition(Competition competition);
    ErrorOr<Competition> GetCompetition(Guid id);
    ErrorOr<UpsertedCompetition> UpsertCompetition(Guid id, Competition competition);
    ErrorOr<Deleted> DeleteCompetition(Guid id);
}