using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the sad message should return sad mood.
        /// </summary>
        /// TC 1.1
        [TestMethod]
        public void GivenSadMessage_ShouldReturn_SadMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Sad mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Sad", mood);
        }

        /// <summary>
        /// Givens the happy message should return happy mood.
        /// </summary>
        /// TC 1.2
        [TestMethod]
        public void GivenHappyMessage_ShouldReturn_HappyMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Happy mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Happy", mood);
        }
    }
}
