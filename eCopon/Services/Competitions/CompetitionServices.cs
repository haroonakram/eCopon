using eCopon.Models;
using ErrorOr;
using eCopon.ServiceErrors;

namespace eCopon.Services.Competitions;

public class CompetitionServices:ICompetitionServices
{
    private static readonly Dictionary<Guid, Competition> _competition = new();
    public ErrorOr<Created> CreateCompetition(Competition competition){
        //store this in somewhere database
        _competition.Add(competition.Id, competition);

        return Result.Created;
    }

    public ErrorOr<Competition> GetCompetition(Guid id){
        if (_competition.TryGetValue(id, out var competition))
        {
            return competition;
        }

        return Errors.Competition.NotFound;
        //return _competition[id];
    }

    public ErrorOr<Deleted> DeleteCompetition(Guid id){
        _competition.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<UpsertedCompetition> UpsertCompetition(Guid id, Competition competition){

        var isNewlyCreated = !_competition.ContainsKey(competition.Id);
        _competition[competition.Id] = competition;
        return new UpsertedCompetition(isNewlyCreated);
    }
}
