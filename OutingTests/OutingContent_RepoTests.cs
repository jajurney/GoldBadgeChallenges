using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repsitory;
using Outings_Repsitory.Outings;

namespace OutingTests
{
    [TestClass]
    public class OutingContent_RepoTests
    {
        [TestMethod]
        public void AddOuting_ShouldReturnBool()
        {
            //Arrange
            OutingContent outingContent = new OutingContent();
            OutingContent_Repo repository = new OutingContent_Repo();
            //Act
            bool addOuting = repository.AddOutingToList(outingContent);
            //Assert
            Assert.IsTrue(addOuting);
        }
        [TestMethod]
        public void GetContents_ShouldReturnList()
        {
            //Arrange
            OutingContent outingContent = new OutingContent();
            OutingContent_Repo repo = new OutingContent_Repo();
            //Act
            repo.AddOutingToList(outingContent);
            List<OutingContent> outingContents = repo.GetOutingContents();
            bool contentsUpdated = outingContents.Contains(outingContent);
            //Arrange
            Assert.IsTrue(contentsUpdated);
        }
        [TestMethod]
        public void GetOutingByDate_ShouldReturnCorrectOuting()
        {
            //Arange
            OutingContent_Repo repo = new OutingContent_Repo();
            OutingContent outingContent = new OutingContent(EventType.Golf,
                30,
                Convert.ToDateTime("7/15/2019"),
                100);
            repo.AddOutingToList(outingContent);
            //Act
            DateTime dateOfEvent = Convert.ToDateTime("7/15/2019");
            OutingContent searchResult = repo.GetOutingByDate(dateOfEvent);
            //Assert
            Assert.AreEqual(searchResult.EventDate, dateOfEvent);
        }
        [TestMethod]
        public void UpdateExitingOuting_ShouldReturnTrue()
        {
            //Arrange
            OutingContent_Repo repo = new OutingContent_Repo();
            OutingContent oldContent = new OutingContent(EventType.Golf,
                30,
                Convert.ToDateTime("7/15/2019"),
                100);
            repo.AddOutingToList(oldContent);
            OutingContent newContent = new OutingContent(EventType.Golf,
                30,
                Convert.ToDateTime("4/15/2019"),
                100);
            //Act
            bool updateOuting = repo.UpdateExistingOutingContent(Convert.ToDateTime("7/15/2019"), newContent);
            //Assert
            Assert.IsTrue(updateOuting);
        }
        [TestMethod]
        public void DeleteOuting_ShouldReturnTrue()
        {
            //Arrange
            OutingContent_Repo repo = new OutingContent_Repo();
            OutingContent outingContent = new OutingContent(EventType.Golf,
                30,
                Convert.ToDateTime("7/15/2019"),
                100);
            repo.AddOutingToList(outingContent);
            //Act
            OutingContent oldContent = repo.GetOutingByDate(Convert.ToDateTime("7/15/2019"));
            bool removeResult = repo.DeleteExistingOutingContent(oldContent);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
