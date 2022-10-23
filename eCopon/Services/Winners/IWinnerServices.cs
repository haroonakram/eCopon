using eCopon.Models;
using ErrorOr;

namespace eCopon.Services.Winners;

public interface IWinnerServices
{
    ErrorOr<Created> CreateWinner(Winner winner);
    ErrorOr<Winner> GetWinner(Guid id);
    ErrorOr<UpsertedWinner> UpsertWinner(Guid id, Winner winner);
    ErrorOr<Deleted> DeleteWinner(Guid id);
}