using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserApp
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// creat a method and having object of class
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        public static object MoodAnalyseObjectCreation(string className, string constructorName)
        {
            string name = @".*" + constructorName + "$"; //created string pattern for constructor name
            bool result = Regex.IsMatch(className, name);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
        /// <summary>
        /// Creates the object of mood analyser using parameterized constructor-UC-5
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Constructor not found
        /// or
        /// No such class found
        /// </exception>
        public static object CreateObjectOfMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message = "")
        {
            Type type = typeof(MoodAnalyser);
            if (type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                    object instance = info.Invoke(new object[] { (message) });
                    return instance;
                }
                else { 
                }
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
        }
    }
}
    
 