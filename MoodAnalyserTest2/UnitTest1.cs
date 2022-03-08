using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;

namespace MoodAnalyserTest2
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the sad message should return sad mood.
        /// </summary>
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

        /// <summary>
        /// Givens the empty mood when analysed should throw mood analysis exception indicating empty mood.
        /// </summary>
        [TestMethod]
        public void GivenEmptyMood_WhenAnalysed_ShouldThrow_MoodAnalysisExceptionIndicatingEmptyMood()
        {
            try
            {
                string message = string.Empty;
                MoodAnalyser mood = new MoodAnalyser(message);
                string moodStr = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }

        /// <summary>
        /// Givens the null mood when analysed should throw mood analysis exception indicating null mood.
        /// </summary>
        [TestMethod]
        public void GivenNULLMood_WhenAnalysed_ShouldThrow_MoodAnalysisExceptionIndicatingNULLMood()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
    }
}