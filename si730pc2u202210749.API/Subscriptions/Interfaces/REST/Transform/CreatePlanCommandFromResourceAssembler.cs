using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;
using si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(resource.Name, resource.MaxUsers, resource.IsDefault);
    }
    
}