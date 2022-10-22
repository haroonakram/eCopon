namespace eCopon.Contracts.Competition
{
    public record CreateCompetitionRequest(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string NumberofWinners,
        string NumberofWithdraws
        ) {
    }
}

