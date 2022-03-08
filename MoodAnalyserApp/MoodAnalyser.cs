using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Analyses the mood and returns happy or mood
        /// </summary>
        /// <returns></returns>
        public string AnalyseMood()
        {
            string mood;
            if (message == "I am in a Any mood")
                mood = "Happy";
            else if (message == "I am in a Sad mood")
                mood = "Sad";
            else
                mood = null;
            return mood;
        }

        //public string AnalyseMood1()
        //{
        //    string mood;
        //    try
        //    {
        //        mood = this.message.Contains("Sad") || this.message.Contains("sad") ? "Sad" : "Happy";
        //    }
        //    catch
        //    {
        //        mood = "Happy";
        //    }
        //    return mood;
        //}

        public string AnalyseMood2()
        {
            string mood;
            try
            {
                mood = this.message.Contains("Sad") || this.message.Contains("sad") ? "Sad" : "Happy";
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
            return mood;
        }       
    }
}
