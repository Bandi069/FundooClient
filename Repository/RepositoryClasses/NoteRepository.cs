
namespace Repository.RepositoryClasses
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using global::Repository.Context;
    using global::Repository.IRepository;
    using Microsoft.AspNetCore.Http;
    using Model.NoteModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// NoteRepository class 
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        private readonly UserContext context;


        public NoteRepository(UserContext context)
        {
            this.context = context;
        }
        public NoteRepository()
        {
        }

        /// <summary>
        /// Add Note method is used to add notes
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<string> AddNotes(NoteModel note)
        {
            NoteModel noteModel = new NoteModel()
            {
                Title = note.Title,
                Description = note.Description,
                Email = note.Email,
                Date = DateTime.Now,
                Archive = note.Archive,
                Pin = note.Pin,
                ChangeColor = note.ChangeColor,
                AddImage = note.AddImage,
                Reminder = note.Reminder,
                Trash = note.Trash
            };
            if (noteModel.Title != " " || noteModel.Description != " ")
            {
                this.context.Notes.Add(noteModel);
                await this.context.SaveChangesAsync();
                return "Note created";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// DeleteNote method is used to delete note by using specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteNote(int id)
        {
            var notes = this.context.Notes.Where(option => option.Id == id).SingleOrDefault();
            if (notes != null)
            {
                context.Notes.Remove(notes);
                context.SaveChanges();
                await this.context.SaveChangesAsync();
                return "Note deleted";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// GetAllNotes method is used to get all notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<NoteModel>> GetAllNotes()
        {
            await this.context.SaveChangesAsync();
            //var notes = this.context.Notes.GroupBy(op => op.Email).Select(grp => grp.ToList()).ToList();
            return this.context.Notes.ToList();
        }

        /// <summary>
        /// GetNote method is used to get note by specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<NoteModel> GetNote(int id)
        {
            var note = this.context.Notes.Where(option => option.Id == id).SingleOrDefault();
            if (note != null)
            {
                return context.Notes.Where(option => option.Id == id).ToList();
            }
            return null;
        }

        /// <summary>
        /// Update Note is used to update note by specific id
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<string> UpdateNote(NoteModel note)
        {
            var notes = context.Notes.Where(option => option.Id == note.Id).SingleOrDefault();
            if (notes != null)
            {
                notes.Email = note.Email;
                notes.Title = note.Title;
                notes.Description = note.Description;
                notes.Date = DateTime.Now;
                notes.ModifiedDate = notes.Date;
                note.ChangeColor = note.ChangeColor;
                await this.context.SaveChangesAsync();
                return "Note updated";
            }
            else
                return default;
        }

        /// <summary>
        /// Trash method is used to send the note to Trash
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Trash(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Trash = true;
                await context.SaveChangesAsync();
                return "Note trashed";
            }
            return null;
        }

        /// <summary>
        /// Empty Trash method is used to empty the trash
        /// </summary>
        /// <returns></returns>
        public async Task<string> EmptyTrash()
        {
            var result = from notes in this.context.Notes where notes.Trash == true select notes;
            if (result != null)
            {
                foreach (var note in result)
                {
                    this.context.Notes.Remove(note);
                }
                var res = await this.context.SaveChangesAsync();
                return "Trash removed"; ;
            }
            return default;
        }

        public async Task<IQueryable<NoteModel>> Search(string searchParameter)
        {
            try
            {
                //var seargfch = "%" + Request.QueryString(searchParameter) + "%";
                var results = this.context.Notes.AsQueryable();

                foreach (var values in searchParameter)
                {
                    results = results.Where(search => search.Description.Contains(values) || search.Title.Contains(values));
                }

                //foreach (var singleResult in results)
                //{
                //    return results.Where(singleSearch => singleSearch.Description == searchParameter ||
                //   singleSearch.Title == searchParameter).ToList().AsQueryable();
                //}
                await this.context.SaveChangesAsync();
                return results;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<NoteModel> TrashList()
        {
            try
            {
                var trashlist = from notes in this.context.Notes where notes.Trash == true select notes;
                if (trashlist != null)
                {
                    return this.context.Notes.Where(list => list.Trash == true).ToList<NoteModel>();
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Restore method is used to get back the specific note that is sent to trash
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Restore(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id && note.Trash == true).SingleOrDefault();
            if (result != null)
            {
                result.Trash = false;
                await this.context.SaveChangesAsync();
                return "Note restored ";
            }
            return null;
        }

        /// <summary>
        /// Restore All method is used to get back all notes that sent to trash
        /// </summary>
        /// <returns></returns>
        public string RestoreAll()
        {
            var list = from notes in context.Notes where notes.Trash == true select notes;
            if (list != null)
            {
                foreach (var note in list)
                {
                    note.Trash = false;
                }
                Task.Run(() => this.context.SaveChanges());
                return "Notes restored ";
            }
            return null;
        }

        /// <summary>
        /// IsArchive method is send the note to archive list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> IsArchive(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Archive = true;
                await this.context.SaveChangesAsync();
                return "Note archived";
            }
            return null;
        }

        /// <summary>
        /// Unarchive method 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> UnArchive(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id && note.Archive == true).SingleOrDefault();
            if (result != null)
            {
                result.Archive = false;
                await this.context.SaveChangesAsync();
                return "Note unarchived";
            }
            return null;
        }

        /// <summary>
        /// Archive List method is used to get the list of notes that are archived
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> ArchiveList()
        {
            var result = from notes in context.Notes where notes.Archive == true select notes;
            if (result != null)
            {
                return context.Notes.Where(list => list.Archive == true).ToList();
            }
            return null;
        }

        /// <summary>
        /// Is Pin method is used to pin the specific note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Ispin(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Pin = true;
                await this.context.SaveChangesAsync();
                return "Note pinned";
            }
            return null;
        }

        /// <summary>
        /// Unpin method 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Unpin(int id)
        {
            var result = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Pin = false;
                await this.context.SaveChangesAsync();
                return "Note unpinned";
            }
            return null;
        }

        /// <summary>
        /// Reminder method is used to set the reminder to the note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reminder"></param>
        /// <returns></returns>
        public async Task<int> Reminder(int id, string reminder)
        {
            var remind = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (remind != null)
            {
                remind.Reminder = reminder.ToString();
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteRemainder(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(op => op.Id == id).SingleOrDefault();
                    var res = Task.Run(() => note.Reminder);
                    if (res != null && !res.Equals(string.Empty))
                    {
                        note.Reminder = string.Empty;
                        var result = await this.context.SaveChangesAsync();
                        return result;
                    }
                    return 0;
                }
                return 0;
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
            var result = this.context.Notes.Where(note => note.Id == id).SingleOrDefault();
            if (result != null)
            {
                if (color != null)
                {
                    result.ChangeColor = color;
                    this.context.Notes.Update(result);
                    await this.context.SaveChangesAsync();
                    return "Note color changed";
                }
                else
                {
                    return null;
                }
            }
            throw new Exception();
        }

        public bool FindById(int id)
        {
            var result = this.context.Notes.Where(op => op.Id == id).SingleOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Upload Image method is used to Upload image to the note 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> UploadImage(IFormFile file, int id)
        {
            
            var stream = file.OpenReadStream();
            var name = file.FileName;
            Account account = new Account("dmdp5jjui","523844292256353", "U1vXZvATQzEk37sZ8QL_43eat4c");
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            //cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
            var data = this.context.Notes.Where(t => t.Id == id).SingleOrDefault();
            data.AddImage = uploadResult.Uri.ToString();
            try
            {
                await this.context.SaveChangesAsync();
                return data.AddImage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}