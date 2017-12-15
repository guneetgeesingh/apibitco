using System;
using Microsoft.EntityFrameworkCore;
using BitCoINCLLC.Controllers;

namespace BitCoINCLLC
{
  public class BitCoINCLLCContext : DbContext
  {
    public BitCoINCLLCContext (DbContextOptions<BitCoINCLLCContext> options) :base (options)
    {
      
    }
    public DbSet<Spinner> Spinners { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Store> Stores { get; set; }



  }
}