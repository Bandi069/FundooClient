// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NoteTest.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="tejasri"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest
{
    using Model.NoteModel;
    using NUnit.Framework;
    using Repository.RepositoryClasses;

    /// <summary>
    /// NoteTest class is used to test the methods in Note Repository
    /// </summary>
    public class NoteTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Add Note method tests the Add Note method in Note Repository
        /// </summary>
        [Test]
        public void AddNote()
        {
            NoteRepository noteRepository = new NoteRepository();
            NoteModel noteModel = new NoteModel()
            {
                Email = "saitejasri.kantheti@gmail.com",
                Title = "title",
                Description = "descrip",
                Archive = true,
                AddImage = "image",
                ChangeColor = "Red",
                Reminder = "remainder",
                Trash = true,
                Pin = true,
            };
            Assert.IsNotNull(noteRepository.AddNotes(noteModel));
        }

        /// <summary>
        /// DeleteNote method is used to test the Delete Note method in Note Repository
        /// </summary>
        [Test]
        public void Deletenote()
        {
            NoteRepository noterepository = new NoteRepository();
            var notemodel = new NoteModel();
            notemodel.Id = 1017;
            Assert.IsNotNull(noterepository.DeleteNote(1017));
        }

        /// <summary>
        /// Update Note method is used test the Update Note in Note Repository
        /// </summary>
        [Test]
        public void Updatenote()
        {
            NoteRepository noterepository = new NoteRepository();
            NoteModel notemodel = new NoteModel()
            {
                Id = 1245,
                Email = "bandivenu89@gmail.com",
                Title = "title",
                Description = "descrip",
                Archive = false,
                AddImage = "NewImage",
                ChangeColor = "Red",
                Reminder = "remaindeme",
                Trash = true,
                Pin = true,
            };
            Assert.IsNotNull(noterepository.UpdateNote(notemodel));
        }

        /// <summary>
        /// GetNote method is used to test the Get Note method in Note Repository
        /// </summary>
        [Test]
        public void Getnote()
        {
            NoteRepository noterepository = new NoteRepository();
            var noteModel = new NoteModel();
            noteModel.Id = 1245;
            Assert.IsNotNull(noterepository.GetNote(1245));
        }
    }
}