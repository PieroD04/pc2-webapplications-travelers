

using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;
using si730pc2u202210749.API.Subscriptions.Domain.Model.ValueObjects;

namespace si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;

public class Plan
{
    //Constructor por defecto
    public Plan()
    {
        Name = new PlanName();
        MaxUsers = new PlanMaxUsers();
        IsDefault = new PlanDefault();
    }
    
    //Constructor por parametros
    public Plan(string name, int maxUsers, int isDefault)
    {
        Name = new PlanName(name);
        MaxUsers = new PlanMaxUsers(maxUsers);
        IsDefault = new PlanDefault(isDefault);
    }
    
    //Constructor por comando
    public Plan(CreatePlanCommand command)
    {
        Name = new PlanName(command.Name);
        MaxUsers = new PlanMaxUsers(command.MaxUsers);
        IsDefault = new PlanDefault(command.IsDefault);
    }

    public void Update(UpdatePlanCommand command)
    {
        Name = new PlanName(command.Name);
        MaxUsers = new PlanMaxUsers(command.MaxUsers);
        IsDefault = new PlanDefault(command.IsDefault);
    }
    
    public int Id { get; }
    public PlanName Name { get; private set; }
    public PlanMaxUsers MaxUsers { get; private set; }
    public PlanDefault IsDefault { get; private set; }
    
    public string PlanName => Name.Name;
    public int PlanMaxUsers => MaxUsers.MaxUsers;
    public int PlanDefault => IsDefault.IsDefault;
}