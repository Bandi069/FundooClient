
namespace Model.LabelModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// LabelModel class is used as model class
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Label Id
        /// </summary>
        private int labelId;

        /// <summary>
        /// Note Id
        /// </summary>
        private int noteId;

        /// <summary>
        /// Label Name
        /// </summary>
        private string labelName;

        /// <summary>
        /// Email Id
        /// </summary>
        private string email;
        
        /// <summary>
        /// Label Id property
        /// </summary>
        [Key]
        public int LabelId { get => this.labelId; set => this.labelId = value; }

        /// <summary>
        /// Note Id property
        /// </summary>
        public int NoteId { get => this.noteId; set => this.noteId = value; }

        /// <summary>
        /// Label Name property
        /// </summary>
        public string LabelName { get => this.labelName; set => this.labelName = value; }

        /// <summary>
        /// Email Id
        /// </summary>
        [ForeignKey("RegisterModel")]
        public string Email { get => this.email; set => this.email = value; }
    }
}