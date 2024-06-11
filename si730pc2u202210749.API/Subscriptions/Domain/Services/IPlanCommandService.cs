using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;

namespace si730pc2u202210749.API.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand createPlanCommand);
    Task<Plan?> Handle(UpdatePlanCommand updatePlanCommand);
    Task<Plan?> Handle(DeletePlanCommand deletePlanCommand);
}