using System;
namespace eCopon.Contracts.Winner
{
    public record UpsertWinnerRequest(
        string Name,
        string Email,
        string Mobile,
        string City,
        DateTime RegisterDate,
        Guid CompetitionId
        )
    {
    }
}

