
namespace Manager.IManager
{
    using Model.LabelModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Label Manager interface consists of abstract methods
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Adds the specified label model.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        string AddLabel(LabelModel labelModel);

        /// <summary>
        /// Updates the specified label model.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        string UpdateLabel(int id, string name);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        string DeleteLabel(int id);

        /// <summary>
        /// Gets all list.
        /// </summary>
        /// <returns></returns>
        Task<List<LabelModel>> GetAllLabels();

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        List<LabelModel> GetLabel(int id);
    }
}