using SmartManager.Domain.SmartContext.Entities;
using SmartManager.Domain.SmartContext.Repositories;
using SmartManager.Infra.SmartContext.DataContext;

namespace SmartManager.Infra.SmartContext.Repositories
{
	public class SmartObjectRepository : Repository<SmartObject>, ISmartObjectRepository
	{
		public SmartObjectRepository(SmartDataContext dataContext) : base("SmartObjects", dataContext) { }
	}
}