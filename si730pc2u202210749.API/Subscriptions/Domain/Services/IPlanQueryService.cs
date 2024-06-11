using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Queries;

namespace si730pc2u202210749.API.Subscriptions.Domain.Services;

public interface IPlanQueryService
{
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);
    Task<Plan?> Handle(GetPlanByIdQuery query);
    Task<Plan?> Handle(GetPlanByName query);
    Task<Plan?> Handle(GetPlanByIsDefault query);
}