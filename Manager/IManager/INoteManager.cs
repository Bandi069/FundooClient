
namespace Manager.IManager
{
    using Microsoft.AspNetCore.Http;
    using Model.NoteModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// INoteManager interface used to create abstract methods of notes
    /// </summary>
    public interface INoteManager
    {
        /// <summary>
        /// AddNotes method is used to add note 
        /// </summary>
        /// <param name="note"></param>
        /// <returns>
        /// added successfully
        /// </returns>
        Task<string> AddNotes(NoteModel note);

        /// <summary>
        /// DeleteNote is used to delete note by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// deleted successfully
        /// </returns>
        Task<string> DeleteNote(int id);

        /// <summary>
        /// GetNote method is used get a specific note by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// a specific note 
        /// </returns>
        List<NoteModel> GetNote(int id);

        /// <summary>
        /// UpdateNote method is used to update already existing note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<string> UpdateNote(NoteModel note);

        /// <summary>
        /// GetAllNotes method is used to get all notes
        /// </summary>
        /// <returns>
        /// list of notes
        /// </returns>
        Task<List<NoteModel>> GetAllNotes();

        /// <summary>
        /// Trash method is used to send the note to trash
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        Task<string> Trash(int id);


        Task<string> EmptyTrash();

        /// <summary>
        /// Gets the archive list.
        /// </summary>
        /// <returns></returns>
        List<NoteModel> ArchiveList();

        /// <summary>
        /// Unpin method is used to unpin the note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> UnPin(int id);

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        Task<string> ChangeColor(int id, string color);

        /// <summary>
        /// Determines whether [is archive] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> IsArchive(int id);

        /// <summary>
        /// Uns the archive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> UnArchive(int id);

        /// <summary>
        /// Restores the trashed note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> Restore(int id);

        /// <summary>
        /// Restores all notes.
        /// </summary>
        /// <returns></returns>
        Task<string> RestoreAll();

        /// <summary>
        /// Determines whether is pin the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> IsPin(int id);

        /// <summary>
        /// Reminder method is used to set the reminder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns></returns>
        Task<string> Reminder(int id, string reminder);

        Task<IQueryable<NoteModel>> Search(string searchParameter);

        /// <summary>
        /// DeleteReminder method is used to remove the reminder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns></returns
        Task<int> DeleteRemainder(int id);
        /// <summary>
        /// Uploads the images.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        Task<string> UploadImage(IFormFile image, int id);

        /// <summary>
        /// Trashes the list.
        /// </summary>
        /// <returns></returns>
        List<NoteModel> TrashList();
    }
}