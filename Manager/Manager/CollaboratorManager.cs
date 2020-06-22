
namespace Manager.Manager
{
    using global::Manager.IManager;
    using Model.Collaborators;
    using Repository.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Collaborator Manager class implements ICollaborator Manager
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// Instantiating ICollaborator interface
        /// </summary>
        private readonly ICollaboratorRepository collaborator;

        /// <summary>
        /// Collaborator Manager constructor used to add dependency
        /// </summary>
        /// <param name="collaborator"></param>
        public CollaboratorManager(ICollaboratorRepository collaborator)
        {
            this.collaborator = collaborator;
        }

        /// <summary>
        /// Adds the collaborator asynchronous.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns>
        /// Added Successfully
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> AddCollaborator(Collaborator collaborator)
        {
            try
            {
              var result=  await this.collaborator.AddCollaboratorToNotes(collaborator);
                return result;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Delete Collaborator method is used to delete collaborator using id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Delted Successfully
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> DeleteCollaborator(int id)
        {
            try
            {
                await this.collaborator.DeleteCollaborator(id);
                return "Deleted Successfully";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<List<Collaborator>> GetAllCollabarators()
        {
            try
            {
              var list=  await this.collaborator.GetAllCollabarators();
                return list;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}