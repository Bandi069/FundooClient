
namespace Manager.Manager
{
    using global::Manager.IManager;
    using Microsoft.AspNetCore.Http;
    using Model.NoteModel;
    using Repository.IRepository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    
    public class NoteManager : INoteManager
    {
        /// <summary>
        /// Instantiating INoteRepository interface
        /// </summary>
        private readonly INoteRepository repository;

        /// <summary>
        /// Adding Dependency
        /// </summary>
        /// <param name="note"></param>
        public NoteManager(INoteRepository note)
        {
            repository = note;
        }

        /// <summary>
        /// AddNotes method is used to add notes
        /// </summary>
        /// <param name="note"></param>
        /// <returns>
        /// added successfully
        /// </returns>
        public async Task<string> AddNotes(NoteModel note)
        {
            var result=await this.repository.AddNotes(note);
                return result;
        }

        /// <summary>
        /// DeleteNote method is used to delete note by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// deleted successfully
        /// </returns>
        public async Task<string> DeleteNote(int id)
        {
             await this.repository.DeleteNote(id);
            return "Deleted Successfully";
        }

        /// <summary>
        /// GetNote method is used to get note by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// specific note details
        /// </returns>
        public List<NoteModel> GetNote(int id)
        {
            var result = this.repository.GetNote(id);
            return result;
        }

        /// <summary>
        /// GetAllNotes method is used to get all notes 
        /// </summary>
        /// <returns>
        /// list of all notes
        /// </returns>
        public async Task<List<NoteModel>> GetAllNotes()
        {
            return await this.repository.GetAllNotes();
        }

        /// <summary>
        /// UpdateNote method is used to update 
        /// </summary>
        /// <param name="note"></param>
        /// <returns>
        /// updated successfully
        /// </returns>
        public async Task<string> UpdateNote(NoteModel note)
        {
            await this.repository.UpdateNote(note);
            return "Updated Successfully";
        }

        /// <summary>
        /// Trash method is used to send the note to Trash
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Trash(int id)
        {
            try
            {
                 await this.repository.Trash(id);
                return "Moved to Trash";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Empty Trash method is used to empty the trash
        /// </summary>
        /// <returns></returns>
        public async Task<string> EmptyTrash()
        {
            try
            {
                await this.repository.EmptyTrash();
                return "Trash Removed";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Archive List method is used to get the list of notes that are archived
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> ArchiveList()
        {
            var list = new List<NoteModel>();
            var result = this.repository.ArchiveList();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Unpin method is used to un pin the note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> UnPin(int id)
        {
            try
            {
                await this.repository.Unpin(id);
                return "Note UnPinned";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Change color method is used to change the color of note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<string> ChangeColor(int id, string color)
        {
            try
            {
                var result=this.repository.ChangeColor(id, color);
                if (result != null)
                {
                    return "Color Changed";
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// IsArchive method is send the note to archive list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> IsArchive(int id)
        {
            try
            {
             await  this.repository.IsArchive(id);
                return "Archived Successfully";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// UnArchive method is used to retrieve the note from Archive list 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> UnArchive(int id)
        {
            try
            {
               await this.repository.UnArchive(id);
                return "UnArchived Successfully";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Restore method is used to get back the specific note that is sent to trash
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Restore(int id)
        {
            try
            {
              await this.repository.Restore(id);
                return "Restored Successfully";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Restore All method is used to get back all notes that sent to trash
        /// </summary>
        /// <returns></returns>
        public async Task<string> RestoreAll()
        {
            try
            {
                this.repository.RestoreAll();
                return "Restored Successfully";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Is Pin method is used to pin the specific note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> IsPin(int id)
        {
            try
            {
               await this.repository.Ispin(id);
                return "Pinned";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Reminder method is used to set the reminder to the note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reminder"></param>
        /// <returns></returns>
        public async Task<string> Reminder(int id, string reminder)
        {
            try
            {
                await this.repository.Reminder(id, reminder);
                return "Reminder Set";
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<IQueryable<NoteModel>> Search(string searchParameter)
        {
            try
            {
                return await this.repository.Search(searchParameter);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<int> DeleteRemainder(int id)
        {
            try
            {
                return await this.repository.DeleteRemainder(id);
               
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Upload Image method is used to Upload image to the note 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> UploadImage(IFormFile image, int id)
        {
            try
            {
                this.repository.UploadImage(image, id);
                return "Image Uploaded";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Trash List method is used get all notes that are sent to trash
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> TrashList()
        {
            try
            {
                var list = new List<NoteModel>();
                var result = this.repository.TrashList();
                foreach (var trash in result)
                {
                    list.Add(trash);
                }
                return list;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}