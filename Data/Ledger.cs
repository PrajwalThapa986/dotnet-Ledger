using Ledger.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Api.Data;

public class LedgerDb(DbContextOptions<LedgerDb> options) : DbContext(options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
}