namespace si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;

//Create Command has attributes from entity with ID

public record UpdatePlanCommand(int Id, string Name, int MaxUsers, int IsDefault);