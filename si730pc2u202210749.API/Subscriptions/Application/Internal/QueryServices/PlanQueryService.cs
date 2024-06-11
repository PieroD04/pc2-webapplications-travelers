using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Queries;
using si730pc2u202210749.API.Subscriptions.Domain.Repositories;
using si730pc2u202210749.API.Subscriptions.Domain.Services;

namespace si730pc2u202210749.API.Subscriptions.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository planRepository) : IPlanQueryService
{
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await planRepository.ListAsync();
    }
    
    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await planRepository.FindByIdAsync(query.PlanId);
    }
    
    public async Task<Plan?> Handle(GetPlanByName query)
    {
        return await planRepository.FindByNameAsync(query.Name);
    }
    
    public async Task<Plan?> Handle(GetPlanByIsDefault query)
    {
        return await planRepository.FindByIsDefaultAsync(query.IsDefault);
    }
}