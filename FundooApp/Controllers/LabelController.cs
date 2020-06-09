
namespace FundooApp.Controllers
{
    using Manager.IManager;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Model.LabelModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// The label manager
        /// </summary>
        public readonly ILabelManager labelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsController"/> class.
        /// </summary>
        /// <param name="labelManager">The label manager.</param>
        public LabelController(ILabelManager label)
        {
            this.labelManager = label;
        }

        /// <summary>
        /// Add Label used to add Labels
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns>
        /// Added Successfully
        /// </returns>
        [HttpPost]
        [Route("addLabel")]
        public ActionResult AddLabel([FromBody]LabelModel labelModel)
        {
            try
            {
                var result = this.labelManager.AddLabel(labelModel);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Deletes the specific label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("deleteLabel")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = this.labelManager.DeleteLabel(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Updates the specified label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateLabel")]
        public IActionResult Update(int id, string name)
        {
            try
            {
                var result = this.labelManager.UpdateLabel(id, name);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets All Labels.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllLabels")]
        public async Task<List<LabelModel>> GetAllLables()
        {
           return await this.labelManager.GetAllLabels();
        }

        /// <summary>
        /// Gets Label by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getLabelById")]
        public List<LabelModel> GetLabel(int id)
        {
            return this.labelManager.GetLabel(id);
        }
    }
}