using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Web.Controllers;


[ApiController]
[Route("api/cashbox")]
public class CashboxController : ControllerBase
{
    private readonly IMediator _mediator;

    public CashboxController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateCashbox(CreateCashboxCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [Authorize(Roles = "admin, Manager, Cashier")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(GetCashboxByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [Authorize(Roles = "admin, Manager")]
    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllCashboxesQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPut]
    public async Task<IActionResult> UpdateCashbox(UpdateCashboxCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = "Admin, Manager, Cashier")]
    [Route("add")]
    [HttpPut]
    public async Task<IActionResult> AddMoney(AddMoneyToCashboxCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = "Admin, Manager")]
    [Route("withdraw")]
    [HttpPut]
    public async Task<IActionResult> WithdrawMoney(WithdrawMoneyFromCashboxCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCashbox(DeleteCashboxCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}