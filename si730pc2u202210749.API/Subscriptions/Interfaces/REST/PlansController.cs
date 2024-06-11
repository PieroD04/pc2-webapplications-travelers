using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Commands;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Queries;
using si730pc2u202210749.API.Subscriptions.Domain.Services;
using si730pc2u202210749.API.Subscriptions.Interfaces.REST.Resources;
using si730pc2u202210749.API.Subscriptions.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730pc2u202210749.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlansController(IPlanQueryService planQueryService, IPlanCommandService planCommandService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Get all plans.",
        Description = "Retrieves all plans.",
        OperationId = "GetAllPlans",
        Tags = new[] { "Plans" }
    )]
    public async Task<IActionResult> GetAllPlans()
    {
        var getAllPlansQuery = new GetAllPlansQuery();
        var plans = await planQueryService.Handle(getAllPlansQuery);
        var planResources = plans.Select(PlanResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(planResources);
    }
    
    [HttpGet("{planId:int}")]
    [SwaggerOperation(
        Summary = "Get a plan by its identifier.",
        Description = "Retrieves a plan by its identifier.",
        OperationId = "GetPlanById",
        Tags = new[] { "Plans" }
    )]
    public async Task<IActionResult> GetPlanById(int planId)
    {
        var getProfileByIdQuery = new GetPlanByIdQuery(planId);
        var profile = await planQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a plan.",
        Description = "Creates a plan.",
        OperationId = "CreatePlan",
        Tags = new[] { "Plans" }
    )]
    public async Task<IActionResult> CreatePlan(CreatePlanResource resource)
    {
        var existingPlan = await planQueryService.Handle(new GetPlanByName(resource.Name));
        if (existingPlan != null)
        {
            return Conflict("A plan with the same name already exists.");
        }

        if (resource.IsDefault == 1)
        {
            var defaultPlan = await planQueryService.Handle(new GetPlanByIsDefault(1));
            if (defaultPlan != null)
            {
                return Conflict("A default plan already exists.");
            }
        }
        
        var createPlanCommand = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var plan = await planCommandService.Handle(createPlanCommand);
        if (plan is null) return BadRequest();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return CreatedAtAction(nameof(GetPlanById), new { planId = planResource.Id }, planResource);
    }

    [HttpPut("{planId:int}")]
    [SwaggerOperation(
        Summary = "Update a plan.",
        Description = "Updates a plan by its identifier.",
        OperationId = "UpdatePlanById",
        Tags = new[] { "Plans" }
    )]
    public async Task<IActionResult> UpdatePlan(int planId, UpdatePlanResource resource)
    {
        var existingPlan = await planQueryService.Handle(new GetPlanByIdQuery(planId));
        if (existingPlan == null) return NotFound();

        if (existingPlan.Name.Name != resource.Name)
        {
            var planWithNewName = await planQueryService.Handle(new GetPlanByName(resource.Name));
            if (planWithNewName != null)
            {
                return Conflict("A plan with the same name already exists.");
            }
        }
        
        if (existingPlan.IsDefault.IsDefault != resource.IsDefault && resource.IsDefault == 1)
        {
            var defaultPlan = await planQueryService.Handle(new GetPlanByIsDefault(1));
            if (defaultPlan != null)
            {
                return Conflict("A default plan already exists.");
            }
        }

        var updatePlanCommand = UpdatePlanCommandFromResourceAssembler.ToCommandFromResource(planId, resource);
        var plan = await planCommandService.Handle(updatePlanCommand);
        if (plan is null) return NotFound();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(planResource);
    }
    
    [HttpDelete("{planId:int}")]
    [SwaggerOperation(
        Summary = "Delete a plan.",
        Description = "Deletes a plan.",
        OperationId = "DeletePlan",
        Tags = new[] { "Plans" }
    )]
    public async Task<IActionResult> DeletePlan(int planId)
    {
        var deletePlanCommand = new DeletePlanCommand(planId);
        var plan = await planCommandService.Handle(deletePlanCommand);
        if (plan is null) return NotFound();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(planResource);
    }

    
}