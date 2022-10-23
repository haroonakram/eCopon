using ErrorOr;

namespace eCopon.ServiceErrors;

public static class Errors
{
    public static class Competition
    {
        public static Error InvalidName => Error.Validation(
            code: "Competition.InvalidName",
            description: $"Competition name must be at least {Models.Competition.MinNameLength}" +
                $" characters long and at most {Models.Competition.MaxNameLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Competition.InvalidDescription",
            description: $"Competition description must be at least {Models.Competition.MinDescriptionLength}" +
                $" characters long and at most {Models.Competition.MaxDescriptionLength} characters long.");

        

        public static Error NotFound => Error.NotFound(
            code: "Competition.NotFound",
            description: "Competition not found");
    }

    public static class Winner
    {
        public static Error InvalidName => Error.Validation(
            code: "Winner.InvalidName",
            description: $"Winner name must be at least {Models.Winner.MinNameLength}  characters long");

        public static Error InvalidEmail => Error.Validation(
            code: "Winner.InvalidEmail",
            description: $"Winner Email must be Valid");

        public static Error InvalidMobile => Error.Validation(
            code: "Winner.InvalidMobile",
            description: $"Winner Mobile Number must be at least {Models.Winner.MinMobileLength}" +
                $" characters long and at most {Models.Winner.MaxMobileLength} characters long.");

        

        public static Error NotFound => Error.NotFound(
            code: "Winner.NotFound",
            description: "Winner not found");
    }
}