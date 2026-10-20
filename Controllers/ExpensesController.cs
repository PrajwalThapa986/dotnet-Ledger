using Ledger.Api.Data;
using Ledger.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(LedgerDb db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetAll(CancellationToken ct)
    => await db.Expenses.AsNoTracking().ToListAsync(ct);

    [HttpPost]
    public async Task<ActionResult<Expense>> Create(Expense expense, CancellationToken ct)
    {
        db.Expenses.Add(expense);
        await db.SaveChangesAsync(ct);
        return CreatedAtAction(nameof(GetAll), new { id = expense.Id }, expense);
    }
}