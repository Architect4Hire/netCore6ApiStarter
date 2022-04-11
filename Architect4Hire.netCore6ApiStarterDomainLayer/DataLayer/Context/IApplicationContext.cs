using System;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Context
{
	public interface IApplicationContext
	{
		DbSet<Product> Products { get; set; }
		Task<int> SaveChanges();

	}
}

