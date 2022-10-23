namespace eCopon.Contracts.Winner
{
    public record CreateWinnerRequest(
        string Name,
        string Email,
        string Mobile,
        string City,
        DateTime RegisterDate,
        Guid CompetitionId
        ) {
    }
}

