using si730pc2u202210749.API.Shared.Domain.Repositories;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;

namespace si730pc2u202210749.API.Subscriptions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<Plan?> FindByNameAsync(string name);
    Task<Plan?> FindByIsDefaultAsync(int isDefault);
}