
namespace FundooApp.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Model.NoteModel;
    using System;
    using Manager.IManager;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;

    /// <summary>
    /// NoteController class extends Controller Base class 
    /// </summary>
    [Authorize]
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// Instatntiation of Interface INoteManager
        /// </summary>
        private readonly INoteManager manager;

        /// <summary>
        /// Adding Dependency 
        /// </summary>
        /// <param name="noteManager"></param>
        public NoteController(INoteManager noteManager)
        {
            manager = noteManager;
        }

        /// <summary>
        /// AddNote method used add new note
        /// </summary>
        /// <param name="note"></param>
        /// <returns>
        /// added successfully
        /// </returns>
        [HttpPost]
        [Route("addnote")]
        public async Task<IActionResult> AddNote([FromBody]NoteModel note)
        {
            try
            {
                var result = await this.manager.AddNotes(note);
               
                    return Ok(new { result });
            }
            catch (Exception exeception)
            {
                return BadRequest(exeception.Message);
            }
        }

        /// <summary>
        /// UpdateNote method is used to update already added note
        /// </summary>
        /// <param name="note"></param>
        /// <returns>
        /// updated successfully
        /// </returns>
        [HttpPut]
        [Route("updateNote")]
        public async Task<IActionResult> UpdateNote([FromBody]NoteModel note)
        {
            try
            {
                var result =await this.manager.UpdateNote(note);
                return Ok(new { result });
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// GetAllNotes method is used to get all added notes
        /// </summary>
        /// <returns>
        /// list of notes
        /// </returns>
        [HttpGet]
        [Route("getNote")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                List<NoteModel> notes = await this.manager.GetAllNotes();
                return Ok(notes);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// GetNode by Id method is used to get a specific note by passing id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// note by id
        /// </returns>
        [HttpGet]
        [Route("getNoteById")]
        public IActionResult GetNote(int id)
        {
            try
            {
                var result = this.manager.GetNote(id);
                return Ok(result);
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// DeleteNote method used to delete note by specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Deleted Successfully
        /// </returns>
        [HttpPut]
        [Route("deleteNote")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
               var result=await this.manager.DeleteNote(id);
                return Ok(new { result });
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Trash method is used to send the specific note to bin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("trash")]
        public async Task<IActionResult> Trash(int id)
        {
            try
            {
                var result = await this.manager.Trash(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Empty Trash method is used to empty the bin
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("emptyTrash")]
        public async Task<IActionResult> EmptyTrash()
        {
            try
            {
                var result = await this.manager.EmptyTrash();
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Trash List method is used to the list of notes in trash
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("trashList")]
        public List<NoteModel> TrashList()
        {
            return this.manager.TrashList();
        }

        /// <summary>
        /// Restore method is used to retrieve the specific note from trash
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("restore")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                var result = await this.manager.Restore(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Restore All method is used retrieve all notes from trash
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("restoreAll")]
        public IActionResult RestoreAll()
        {
            try
            {
                var result = this.manager.RestoreAll();
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Is Archive method is used to send the note archive list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("isArchive")]
        public async Task<IActionResult> IsArchive(int id)
        {
            try
            {
                var result = await this.manager.IsArchive(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Un Archive method is used to retrieve specific note from archive list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("unArchive")]
        public async Task<IActionResult> UnArchive(int id)
        {
            try
            {
                var result = await this.manager.UnArchive(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Archive List method is used to get the total notes in that are archived
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("archiveList")]
        public List<NoteModel> ArchiveList()
        {
            return this.manager.ArchiveList();
        }

        /// <summary>
        /// Is Pin method is used to pin the specific note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("isPin")]
        public async Task<IActionResult> IsPin(int id)
        {
            try
            {
                var result = await this.manager.IsPin(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Un Pin method is used to un pin the specific note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("unPin")]
        public async Task<IActionResult> UnPin(int id)
        {
            try
            {
                var result =await this.manager.UnPin(id);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Reminder method is used to set the reminder to the note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reminder"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("reminder")]
        public async Task<IActionResult> Reminder(int id, string reminder)
        {
            try
            {
                var result =await this.manager.Reminder(id, reminder);
                return this.Ok(new { result });
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
        [HttpPut]
        [Route("deleteReminder")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            try
            {
                var result = await this.manager.DeleteRemainder(id);
                return this.Ok("Reminder deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search(string searchParameter)
        {
            var result =await this.manager.Search(searchParameter);
            try
            {
                if (result.Count() > 0)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("No notes present ");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        
        /// <summary>
        /// Chnage Color method is used to change the color of the note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("changeColor")]
        public async Task<IActionResult> ChangeColor(int id, string changeColor)
        {
            try
            {
                var result = await this.manager.ChangeColor(id, changeColor);
                if (result != null)
                {
                    return this.Ok(new { result });
                }
                else
                {
                    return this.BadRequest(result);
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Upload Image method is used to upload the image to the note
        /// </summary>
        /// <param name="image"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile image, int id)
        {
            try
            {
                var result = await this.manager.UploadImage(image, id);
                return this.Ok(result);
            }
            catch (Exception exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
    }
}