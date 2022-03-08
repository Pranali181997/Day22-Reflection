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
        /// Analyses the mood and returns happy or sad.
        /// </summary>
        /// <returns></returns>
        public string AnalyseMood()
        {
            string mood;
            try
            {
                mood = this.message.Contains("Sad") || this.message.Contains("sad") ? "Sad" : "Happy";
            }
            catch
            {
                mood = "Happy";
            }
            return mood;
        }
    }
}