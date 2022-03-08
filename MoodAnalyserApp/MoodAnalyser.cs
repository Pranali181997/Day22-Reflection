using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyser
    {
        public string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
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
        /// Analyses the mood.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Mood should not be empty
        /// or
        /// Mood should not be null
        /// </exception>
        public string AnalyseMood()
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
