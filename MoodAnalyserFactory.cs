﻿
using System.Reflection;
namespace MoodAnalyserProject
{
    public class MoodAnalyserFactory
    {

        public static object CreateMoodAnalyse(string className, string constructor)
        {

            if (className.Equals(constructor))
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not Found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }
    }

}
