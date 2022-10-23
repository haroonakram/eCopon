namespace eCopon.Contracts.Winner
{
    public record WinnerResponse(
        Guid id,
        string Name,
        string Email,
        string Mobile,
        string City,
        DateTime RegisterDate,
        Guid CompetitionId,
        DateTime LastModifiedDateTime
        )
    {
    }
}

