﻿using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;
using si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Transform;

public static class UpdatePlanCommandFromResourceAssembler
{
    public static UpdatePlanCommand ToCommandFromResource(UpdatePlanResource resource)
    {
        return new UpdatePlanCommand(resource.Id, resource.Name, resource.MaxUsers, resource.IsDefault);
    }
    
}