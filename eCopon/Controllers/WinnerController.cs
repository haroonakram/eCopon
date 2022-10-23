using Microsoft.AspNetCore.Mvc;
using eCopon.Contracts.Winner;
using eCopon.Models;
using eCopon.Services.Winners;
using ErrorOr;
using eCopon.ServiceErrors;

namespace eCopon.Controllers;

public class WinnerController : ApiController
{
    private readonly IWinnerServices _winnerServices;

    public WinnerController(IWinnerServices winnerServices){
        _winnerServices = winnerServices;
    }

    //insert method
    [HttpPost]
    public IActionResult CreateWinner(CreateWinnerRequest request)
    {
        ErrorOr<Winner> requestToWinnerResult = Winner.From(request);

        //checking the validation
        if (requestToWinnerResult.IsError)
        {
            return Problem(requestToWinnerResult.Errors);
        }
        //results are good to save
        var winner = requestToWinnerResult.Value;
        //SAVE INTO THE DATABASE
        ErrorOr<Created> createWinnerResult = _winnerServices.CreateWinner(winner);

        return createWinnerResult.Match(
            created => CreatedAtGetWinner(winner),
            errors => Problem(errors));
    }
    
    //getting the id
    [HttpGet("{id:guid}")]
    public IActionResult GetWinner(Guid id){
        
        ErrorOr<Winner> getWinnerResult = _winnerServices.GetWinner(id);
        //returning the result
        return getWinnerResult.Match(
            Winner => Ok(MapWinnerResponse(Winner)),
            errors => Problem(errors)
        );
    }

    //update request
    [HttpPut("{id:guid}")]
    public IActionResult UpsertWinner(Guid id, UpsertWinnerRequest request){
        
        ErrorOr<Winner> requestToWinnerResult = Winner.From(id, request);

        //checking the validation
        if (requestToWinnerResult.IsError)
        {
            return Problem(requestToWinnerResult.Errors);
        }
        //results are good to save
        var winner = requestToWinnerResult.Value;

        ErrorOr<UpsertedWinner> upsertedResult = _winnerServices.UpsertWinner(id, winner);

        return upsertedResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetWinner(winner) : NoContent(),
            errors => Problem(errors)
        );
    }

    //delete request
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteWinner(Guid id){
        ErrorOr<Deleted> deleteWinnerResult =  _winnerServices.DeleteWinner(id);
        return deleteWinnerResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static WinnerResponse MapWinnerResponse(Winner winner)
    {
        return new WinnerResponse(
            winner.Id,
            winner.Name,
            winner.Email,
            winner.Mobile,
            winner.City,
            winner.RegisterDate,
            winner.CompetitionId,
            winner.LastModifiedDateTime
        );
    }

    private CreatedAtActionResult CreatedAtGetWinner(Winner winner)
    {
        return CreatedAtAction(
            actionName: nameof(GetWinner),
            routeValues: new { id = winner.Id },
            value: MapWinnerResponse(winner));
    }
}