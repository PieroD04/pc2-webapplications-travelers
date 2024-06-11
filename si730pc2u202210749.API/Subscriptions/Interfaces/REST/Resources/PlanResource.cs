namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

// Resource is a record with data of a resource and an ID
//Upper Camel Case
public record PlanResource(int Id, string PlanName, int PlanMaxUsers);