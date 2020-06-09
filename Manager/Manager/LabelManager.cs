
namespace Manager.Manager
{
    using global::Manager.IManager;
    using Model.LabelModels;
    using Repository.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Label Manager Class implements ILabelManger interface
    /// </summary>
    /// <seealso cref="Manager.Interface.ILabelManager" />
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// The label repo
        /// </summary>
        public readonly ILabelRepository label;

        public LabelManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class.
        /// </summary>
        /// <param name="labelRepo">The label repo.</param>
        public LabelManager(ILabelRepository labelRepository)
        {
            this.label = labelRepository;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// Added Successfully
        /// </returns>
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                this.label.AddLabel(labelModel);
                return "Added Successfully";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }

        /// <summary>
        /// Deleted the specific label
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Deleted Successfully
        /// </returns>
        public string DeleteLabel(int id)
        {
            try
            {
                this.label.DeleteLabel(id);
                return "Deleted Successfully";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        /// <summary>
        /// Gets All Labels 
        /// </summary>
        /// <returns>
        /// list of labels
        /// </returns>
        public async Task<List<LabelModel>> GetAllLabels()
        {
            try
            {
               
                return await this.label.GetAllLabels();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Gets a specific label by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LabelModel> GetLabel(int id)
        {
            try
            {
                var list = new List<LabelModel>();
                var result = this.label.GetLabel(id);
                foreach (var item in result)
                {
                    list.Add(item);
                }
                return list;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Updates the specific label
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns>
        /// Updated Successfully
        /// </returns>
        public string UpdateLabel(int id, string name)
        {
            try
            {
                this.label.UpdateLabel(id, name);
                return "Updated Successfully";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}