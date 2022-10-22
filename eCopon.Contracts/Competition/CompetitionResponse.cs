namespace eCopon.Contracts.Competition
{
    public record CompetitionResponse(
        Guid id,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        DateTime LastModifiedDateTime,
        string NumberofWinners,
        string NumberofWithdraws
        )
    {
    }
}

