namespace FundooApp.Controllers
{
    using Manager.IManager;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Model.Collaborators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        
        private readonly ICollaboratorManager collaborator;
        
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaborator = collaboratorManager;
        }
               
        [HttpPost]
        [Route("addColloborator")]
        public async Task<IActionResult> AddColloborator([FromBody]Collaborator collaborator)
        {
            try
            {
                var result =await this.collaborator.AddCollaborator(collaborator);
                return this.Ok(new { result });
            }
            catch(Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("deleteCollaborator")]
        public async Task<IActionResult> DeleteCollaborator(int id)
        {
            try
            {
                var result = await this.collaborator.DeleteCollaborator(id);
                return  this.Ok(new { result });
            }
            catch(Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("getAllCollaborators")]
        public async Task<IActionResult> GetAllCollaborators()
        {
            try
            {
                var result = await this.collaborator.GetAllCollabarators();
                return this.Ok(result);
            }
            catch(Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
    }
}