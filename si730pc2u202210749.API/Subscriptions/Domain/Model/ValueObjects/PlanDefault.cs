namespace si730pc2u202210749.API.Subscriptions.Domain.Model.ValueObjects;

public class PlanDefault
{
    public int IsDefault { get; }

    public PlanDefault()
    {
        IsDefault = 0;
    }
    
    public PlanDefault(int isDefault)
    {
        if (isDefault is < 0 or > 1)
        {
            throw new ArgumentException("IsDefault must be 0 or 1", nameof(isDefault));
        }

        IsDefault = isDefault;
    }
};