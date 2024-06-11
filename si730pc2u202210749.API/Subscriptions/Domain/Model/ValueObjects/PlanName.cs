namespace si730pc2u202210749.API.Subscriptions.Domain.Model.ValueObjects;

public record PlanName(string Name)
{
    public PlanName() : this(string.Empty){ }
}
