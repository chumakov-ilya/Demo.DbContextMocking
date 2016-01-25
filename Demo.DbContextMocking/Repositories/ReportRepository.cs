using System.Collections.Generic;
using System.Linq;
using Demo.DbContextMocking.Models;
using Ninject;

namespace Demo.DbContextMocking
{
	public class ReportRepository
	{
		[Inject]
		public IContextFactory ContextFactory { get; set; }

		public List<Report> GetReports()
		{
			using (var context = ContextFactory.Create())
			{
				return context.Reports.ToList();
			}

		}
	}
}