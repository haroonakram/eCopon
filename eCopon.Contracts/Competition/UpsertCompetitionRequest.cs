using System;
namespace eCopon.Contracts.Competition
{
    public record UpsertCompetitionRequest(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string NumberofWinners,
        string NumberofWithdraws
        )
    {
    }
}

