
namespace Repository.IRepository
{
    using Microsoft.AspNetCore.Http;
    using Model.NoteModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface INoteRepository
    {
        Task<string> AddNotes(NoteModel note);
        Task<string> UpdateNote(NoteModel note);
        Task<string> DeleteNote(int id);
        Task<List<NoteModel>> GetAllNotes();
        List<NoteModel> GetNote(int id);
        Task<string> Trash(int id);
        Task<string> EmptyTrash();
        List<NoteModel> TrashList();
        Task<string> Restore(int id);
        string RestoreAll();
        Task<string> IsArchive(int id);
        Task<string> UnArchive(int id);
        List<NoteModel> ArchiveList();
        Task<IQueryable<NoteModel>> Search(string searchParameter);
        Task<string> Ispin(int id);
        Task<string> Unpin(int id);
        Task<int> Reminder(int id, string reminder);
        Task<int> DeleteRemainder(int id);
        Task<string> ChangeColor(int id, string color);
        Task<string> UploadImage(IFormFile image, int id);
    }
}