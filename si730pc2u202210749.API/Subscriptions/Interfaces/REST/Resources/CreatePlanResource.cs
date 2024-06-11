namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;

//Create Resource is a record with data of a resource but without an ID
//Upper Camel Case
public record CreatePlanResource(string Name, int MaxUsers, int IsDefault);