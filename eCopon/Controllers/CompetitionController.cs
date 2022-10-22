using Microsoft.AspNetCore.Mvc;
using eCopon.Contracts.Competition;
using eCopon.Models;
using eCopon.Services.Competitions;
using ErrorOr;
using eCopon.ServiceErrors;

namespace eCopon.Controllers;

public class CompetitionController : ApiController
{
    private readonly ICompetitionServices _competitionServices;

    public CompetitionController(ICompetitionServices competitionServices){
        _competitionServices = competitionServices;
    }

    //insert method
    [HttpPost]
    public IActionResult CreateBreakfast(CreateCompetitionRequest request)
    {
        ErrorOr<Competition> requestToCompetitionResult = Competition.From(request);

        //checking the validation
        if (requestToCompetitionResult.IsError)
        {
            return Problem(requestToCompetitionResult.Errors);
        }
        //results are good to save
        var competition = requestToCompetitionResult.Value;
        //SAVE INTO THE DATABASE
        ErrorOr<Created> createCompetitionResult = _competitionServices.CreateCompetition(competition);

        return createCompetitionResult.Match(
            created => CreatedAtGetCompetition(competition),
            errors => Problem(errors));
    }
    
    //getting the id
    [HttpGet("{id:guid}")]
    public IActionResult GetCompetition(Guid id){
        
        ErrorOr<Competition> getCompetitionResult = _competitionServices.GetCompetition(id);
        //returning the result
        return getCompetitionResult.Match(
            competition => Ok(MapCompetitionResponse(competition)),
            errors => Problem(errors)
        );
    }

    //update request
    [HttpPut("{id:guid}")]
    public IActionResult UpsertCompetition(Guid id, UpsertCompetitionRequest request){
        
        ErrorOr<Competition> requestToCompetitionResult = Competition.From(id, request);

        //checking the validation
        if (requestToCompetitionResult.IsError)
        {
            return Problem(requestToCompetitionResult.Errors);
        }
        //results are good to save
        var competition = requestToCompetitionResult.Value;

        ErrorOr<UpsertedCompetition> upsertedResult = _competitionServices.UpsertCompetition(id, competition);

        return upsertedResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetCompetition(competition) : NoContent(),
            errors => Problem(errors)
        );
    }

    //delete request
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCompetition(Guid id){
        ErrorOr<Deleted> deleteCompetitionResult =  _competitionServices.DeleteCompetition(id);
        return deleteCompetitionResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static CompetitionResponse MapCompetitionResponse(Competition competition)
    {
        return new CompetitionResponse(
            competition.Id,
            competition.Name,
            competition.Description,
            competition.StartDate,
            competition.EndDate,
            competition.LastModifiedDateTime,
            competition.NumberofWinners,
            competition.NumberofWithdraws
        );
    }

    private CreatedAtActionResult CreatedAtGetCompetition(Competition competition)
    {
        return CreatedAtAction(
            actionName: nameof(GetCompetition),
            routeValues: new { id = competition.Id },
            value: MapCompetitionResponse(competition));
    }
}