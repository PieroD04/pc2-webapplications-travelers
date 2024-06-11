using MySqlX.XDevAPI;
using si730pc2u202210749.API.Shared.Domain.Repositories;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;
using si730pc2u202210749.API.Subscriptions.Domain.Repositories;
using si730pc2u202210749.API.Subscriptions.Domain.Services;

namespace si730pc2u202210749.API.Subscriptions.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(command.Name, command.MaxUsers, command.IsDefault);
        try
        {
            await planRepository.AddAsync(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the client: {e.Message}");
            return null;
        }
    }
    
    public async Task<Plan?> Handle(UpdatePlanCommand command)
    {
        var plan = await planRepository.FindByIdAsync(command.Id);
        if (plan == null)
        {
            Console.WriteLine($"Plan with id {command.Id} not found");
            return null;
        }
        plan.Update(command);
        try
        {
            planRepository.Update(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the client: {e.Message}");
            return null;
        }
    }
    
    public async Task<Plan?> Handle(DeletePlanCommand command)
    {
        var plan = await planRepository.FindByIdAsync(command.PlanId);
        if (plan == null)
        {
            Console.WriteLine($"Plan with id {command.PlanId} not found");
            return null;
        }
        try
        {
            planRepository.Remove(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the plan: {e.Message}");
            return null;
        }
    }
}