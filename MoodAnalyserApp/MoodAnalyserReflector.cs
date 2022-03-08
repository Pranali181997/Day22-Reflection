using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">No such method found</exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserApp.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserFactory.CreateObjectOfMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo method = type.GetMethod(methodName);
                object mood = method.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Message cannot be null
        /// or
        /// Field not found
        /// </exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser mood = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Message cannot be null");
                }
                field.SetValue(mood, message);
                return mood.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
