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
}