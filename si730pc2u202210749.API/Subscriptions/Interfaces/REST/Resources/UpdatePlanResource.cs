namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

//Update Resource is a record with data of a resource but with an ID
//Upper Camel Case
public record UpdatePlanResource(int Id, string Name, int MaxUsers, int IsDefault);