using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repsitory.Outings;

namespace OutingTests
{
    [TestClass]
    public class OutingContentTests
    {
        [TestMethod]
        public void SetPeopleAttending_ShouldReturnInt()
        {
            //Arrange
            OutingContent outingContent = new OutingContent();
            //Act
            outingContent.PeopleAttended = 30;
            //Assert
            Assert.AreEqual(outingContent.PeopleAttended, 30);
        }
    }
}
