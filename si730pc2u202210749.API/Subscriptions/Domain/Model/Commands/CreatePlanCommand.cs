namespace si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;

//Create Command has attributes from entity without ID
public record CreatePlanCommand(string Name, int MaxUsers, int IsDefault);