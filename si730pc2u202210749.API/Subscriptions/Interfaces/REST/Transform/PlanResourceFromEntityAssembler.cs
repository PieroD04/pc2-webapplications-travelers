using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;
using si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(entity.Id, entity.PlanName, entity.PlanMaxUsers);
    }
}