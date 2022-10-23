using eCopon.Models;
using ErrorOr;
using eCopon.ServiceErrors;

namespace eCopon.Services.Winners;

public class WinnerServices:IWinnerServices
{
    private static readonly Dictionary<Guid, Winner> _winner = new();
    public ErrorOr<Created> CreateWinner(Winner winner){
        //store this in somewhere database
        _winner.Add(winner.Id, winner);
        return Result.Created;
    }

    public ErrorOr<Winner> GetWinner(Guid id){
        if (_winner.TryGetValue(id, out var winner))
        {
            return winner;
        }

        return Errors.Winner.NotFound;
    }

    public ErrorOr<Deleted> DeleteWinner(Guid id){
        _winner.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<UpsertedWinner> UpsertWinner(Guid id, Winner winner){

        var isNewlyCreated = !_winner.ContainsKey(winner.Id);
        _winner[winner.Id] = winner;
        return new UpsertedWinner(isNewlyCreated);
    }
}
