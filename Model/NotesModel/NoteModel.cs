
namespace Model.NoteModel
{
    using System;

    /// <summary>
    /// NoteModel class is used as Model class for Notes
    /// </summary>
    public class NoteModel
    {
        /// <summary>
        /// Id for Note
        /// </summary>
        private int id;

        /// <summary>
        /// Title of Note
        /// </summary>
        private string title;

        /// <summary>
        /// Description of Note
        /// </summary>
        private string description;

        /// <summary>
        /// Email 
        /// </summary>
        private string email;

        /// <summary>
        /// Date when Note is added
        /// </summary>
        private DateTime? date;

        /// <summary>
        /// ModifiedDate when note is modified
        /// </summary>
        private DateTime? modifiedDate;

        /// <summary>
        /// archieve is used to hide the note
        /// </summary>
        private bool archive;

        /// <summary>
        /// pin the note
        /// </summary>
        private bool pin;

        /// <summary>
        /// Changes the color
        /// </summary>
        private string changeColor;

        /// <summary>
        /// Adds image to the note
        /// </summary>
        private string addImage;

        /// <summary>
        /// Remainder is used to set the remainder
        /// </summary>
        private string reminder;

        /// <summary>
        /// trash the note
        /// </summary>
        private bool trash;

        /// <summary>
        /// Id of the note
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Title of the note
        /// </summary>
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// Description of the note
        /// </summary>
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Email 
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Date when note created
        /// </summary>
        public DateTime? Date { get => date; set => date = value; }

        /// <summary>
        /// Modified date of the note
        /// </summary>
        public DateTime? ModifiedDate { get => modifiedDate; set => modifiedDate = value; }

        /// <summary>
        /// Archive the note
        /// </summary>
        public bool Archive { get => archive; set => archive = value; }

        /// <summary>
        /// Pin the note
        /// </summary>
        public bool Pin { get => pin; set => pin = value; }

        /// <summary>
        /// Changes the color of the note
        /// </summary>
        public string ChangeColor { get => changeColor; set => changeColor = value; }

        /// <summary>
        /// Adds the image to the note
        /// </summary>
        public string AddImage { get => addImage; set => addImage = value; }

        /// <summary>
        /// Reminder to the note
        /// </summary>
        public string Reminder { get => reminder; set => reminder = value; }

        /// <summary>
        /// Trash the note
        /// </summary>
        public bool Trash { get => trash; set => trash = value; }
    }
}