using eCopon.Contracts.Competition;
using eCopon.ServiceErrors;
using ErrorOr;

namespace eCopon.Models;

public class Competition {
    
    public const int MinNameLength = 3;
    public const int MaxNameLength = 150;

    public const int MinDescriptionLength = 200;
    public const int MaxDescriptionLength = 1000;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public DateTime LastModifiedDateTime { get; }
    public string NumberofWinners { get; }
    public string NumberofWithdraws { get; }

    private Competition(
        Guid id,
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        DateTime lastModifiedDateTime,
        string numberofWinners,
        string numberofWithdraws
    ){
        //enforce invariants
        Id = id;
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        LastModifiedDateTime = lastModifiedDateTime;
        NumberofWinners = numberofWinners;
        NumberofWithdraws = numberofWithdraws;

    }

    public static ErrorOr<Competition> Create(
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        string numberofWinners,
        string numberofWithdraws,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Competition.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Competition.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Competition(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDate,
            endDate,
            DateTime.UtcNow,
            numberofWinners,
            numberofWithdraws);
    }

    public static ErrorOr<Competition> From(CreateCompetitionRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.NumberofWinners,
            request.NumberofWithdraws);
    }

    public static ErrorOr<Competition> From(Guid id, UpsertCompetitionRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.NumberofWinners,
            request.NumberofWithdraws,
            id);
    }
}