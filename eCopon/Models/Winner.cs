using eCopon.Contracts.Winner;
using eCopon.ServiceErrors;
using ErrorOr;

namespace eCopon.Models;

public class Winner {
    
    public const int MinNameLength = 3;
    public const int MinEmailLength = 7;
    public const int MinMobileLength = 10;
    public const int MaxMobileLength = 10;

    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string Mobile { get; }
    public string City { get; }
    public DateTime RegisterDate { get; }

    public Guid CompetitionId { get; }
    public DateTime LastModifiedDateTime { get; }

    private Winner(
        Guid id,
        string name,
        string email,
        string mobile,
        string city,
        DateTime registerDate,
        Guid competitionId,
        DateTime lastModifiedDate
    ){
        Id = id;
        Name = name;
        Email = email;
        Mobile = mobile;
        City = city;
        RegisterDate = registerDate;
        CompetitionId = competitionId;
        LastModifiedDateTime = lastModifiedDate;

    }

    public static ErrorOr<Winner> Create(
        string name,
        string email,
        string mobile,
        string city,
        Guid competitionId,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength)
        {
            errors.Add(Errors.Winner.InvalidName);
        }

        if (email.Length is < MinEmailLength)
        {
            errors.Add(Errors.Winner.InvalidEmail);
        }

        if (mobile.Length is < MinMobileLength or > MaxMobileLength)
        {
            errors.Add(Errors.Winner.InvalidMobile);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Winner(
            id ?? Guid.NewGuid(),
            name,
            email,
            mobile,
            city,
            DateTime.UtcNow,
            competitionId,
            DateTime.UtcNow
            );
    }

    public static ErrorOr<Winner> From(CreateWinnerRequest request)
    {
        return Create(
            request.Name,
            request.Email,
            request.Mobile,
            request.City,
            request.CompetitionId);
    }

    public static ErrorOr<Winner> From(Guid id, UpsertWinnerRequest request)
    {
        return Create(
            request.Name,
            request.Email,
            request.Mobile,
            request.City,
            request.CompetitionId,
            id);
    }
}