
namespace Manager.IManager
{
    using Model.Collaborators;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns></returns>
        Task<string> AddCollaborator(Collaborator collaborator);

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns></returns>
        Task<string> DeleteCollaborator(int id);

        Task<List<Collaborator>> GetAllCollabarators();
    }
}