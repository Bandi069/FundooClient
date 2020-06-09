
namespace Repository.IRepository
{
    using Model.LabelModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// ILabel Repository interface is used to define abstract methods
    /// </summary>
    public interface ILabelRepository
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// 
        /// </returns>
        string AddLabel(LabelModel labelModel);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        string UpdateLabel(int id, string name);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// 
        /// </returns>
        string DeleteLabel(int id);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        Task<List<LabelModel>> GetAllLabels();

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// 
        /// </returns>
        List<LabelModel> GetLabel(int id);
    }
}