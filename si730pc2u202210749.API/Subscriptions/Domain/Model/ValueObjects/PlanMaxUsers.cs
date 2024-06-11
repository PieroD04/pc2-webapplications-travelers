namespace si730pc2u202210749.API.Subscriptions.Domain.Model.ValueObjects;

public class PlanMaxUsers
{
    public int MaxUsers { get; }

    public PlanMaxUsers()
    {
        MaxUsers = 0;
    }

    public PlanMaxUsers(int maxUsers)
    {
        if (maxUsers <= 0)
        {
            throw new ArgumentException("MaxUsers must be greater than 0", nameof(maxUsers));
        }

        MaxUsers = maxUsers;
    }
    
};