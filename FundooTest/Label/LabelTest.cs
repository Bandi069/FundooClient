// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LabelTest.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="tejasri"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Label Test class is used to test the methods in label.
    /// </summary>
    public class LabelTest
    {
        /// <summary>
        /// AddLabel Test method tests the AddLabel method in LabelRepository
        /// </summary>
        [Test]
        public void AddLabelTest()
        {
            LabelRepository repository = new LabelRepository();
            LabelModel label = new LabelModel
            {
                LabelId = 1,
                LabelName = "Sample",
                NoteId = 1
            };
            Assert.IsNotNull(repository.AddLabel(label));
        }

        /// <summary>
        /// Delete Label Test is used to Test the Delete Label in Label Manager
        /// </summary>
        [Test]
        public void DeleteLabel()
        {
            LabelManager label = new LabelManager();
            var result = label.DeleteLabel(1);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Update Label is used to test the Update Label method in LabelManager
        /// </summary>
        [Test]
        public void UpdateLabel()
        {
            var label = new LabelManager();
            var id = 1003;
            var labelName = "Hello";
            var labelModel = new LabelModel()
            {
                LabelId = 1001,
                LabelName = "Hello"
            };
            var result = label.UpdateLabel(id, labelName, labelModel);
            Assert.IsNotNull(result);
        }
    }
}