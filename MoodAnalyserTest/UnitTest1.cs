using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;

namespace MoodAnalyserTest6
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens I am in a Sad mood message when analysed should return sad mood.-1.1
        /// </summary>
        [TestMethod]
        public void GivenSadMessage_WhenAnalysed_ShouldReturnSadMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Sad mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Sad", mood);
        }

        /// <summary>
        /// Givens the I am in a Any mood message when analysed should return happy mood.-1.2
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenAnalysed_ShouldReturnHappyMood()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Any mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Happy", mood);
        }

        /// <summary>
        /// Givens the empty mood when analysed should throw mood analysis exception indicating empty mood.-3.1
        /// </summary>
        [TestMethod]
        public void GivenEmptyMood_WhenAnalysed_ShouldThrowMoodAnalysisExceptionIndicatingEmptyMood()
        {
            try
            {
                string message = string.Empty;
                MoodAnalyser mood = new MoodAnalyser(message);
                string moodStr = mood.AnalyseMood2();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }

        /// <summary>
        /// Givens the null mood when analysed should throw mood analysis exception indicating null mood.-3.2
        /// </summary>
        [TestMethod]
        public void GivenNULLMood_WhenAnalysed_ShouldThrowMoodAnalysisExceptionIndicatingNULLMood()
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

        /// <summary>
        /// Givens the mood analyser class name when analysed should return mood analyser object.-uc-4.1
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassName_WhenAnalysed_ShouldReturn_MoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser");
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        /// <summary>
        /// Givens the improper class name when analyse should throw mood analysis exception.-uc-4.2
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("abc", "abc");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }

        /// <summary>
        /// Givens the improper constructor name when analyse should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_WhenAnalyse_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("Mood", "MoodAnalyser");//here checking the constructor name should be same as that of class name
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }

        /// <summary>
        /// Givens the mood analyser when analysed using parameterized constructor should return mood analyser object.-5.1
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyser_WhenAnalysed_UsingParameterizedConstructor_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser", "Happy");
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        /// <summary>
        /// Givens the improper class name when analyse using parameterised constructor should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_WhenAnalyse_UsingParameterisedConstructor_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("Mood", "MoodAnalyser", "Happy");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }

        /// <summary>
        /// Givens the improper constructor name when analyse using parameterised constructor should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_WhenAnalyse_UsingParameterisedConstructor_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "Mood", "Happy");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }

        /// <summary>
        /// Givens the mood analyser without message when analysed using parameterized constructor should return mood analyser object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserWithoutMessage_WhenAnalysed_UsingParameterizedConstructor_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser");
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        /// <summary>
        /// Givens the happy message should return happy mood.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_ShouldReturnHappyMood()
        {

            string expected = "Happy";
            string result = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual("Happy", result);
        }

        /// <summary>
        /// Givens the improper method should throw mood analyser custom exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperMethod_ShouldThrowMoodAnalyserCustomException()
        {
            try
            {
                string result = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "Analyse");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such method found", e.Message);
            }
        }

        /// <summary>
        /// Givens the happy message with reflector should return happy mood.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WithReflector_ShouldReturnHappyMood()
        {
            string expected = "Happy";
            string result = MoodAnalyserReflector.SetField("Happy", "message");
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Givens the improper field should throw mood analyser custom exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperField_ShouldThrowMoodAnalyserCustomException()
        {
            try
            {
                string result = MoodAnalyserReflector.SetField("Happy", "msg");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Field not found", e.Message);
            }
        }

        /// <summary>
        /// Givens the null message should throw mood analyser custom exception.
        /// </summary>
        [TestMethod]
        public void GivenNullMessage_ShouldThrowMoodAnalyserCustomException()
        {
            try
            {
                string message = null;
                string result = MoodAnalyserReflector.SetField(message, "message");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Message cannot be null", e.Message);
            }
        }
    }
}