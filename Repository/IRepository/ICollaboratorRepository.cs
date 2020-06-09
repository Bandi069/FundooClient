
namespace Repository.IRepository
{
    using Model.Collaborators;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// ICollaborator interface consists of abstract methods
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborators to notes.
        /// </summary>
        /// <param name="collaborator">The collaborator .</param>
        /// <returns></returns>
        Task<string> AddCollaboratorToNotes(Collaborator collaborator);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator .</param>
        /// <returns></returns>
        Task<string> DeleteCollaborator(int id);

        Task<List<Collaborator>> GetAllCollabarators();
    }
}
