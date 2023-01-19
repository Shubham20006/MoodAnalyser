
using MoodAnalyserProject;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethodForHappyMood()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
            string expected = "happy";
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForSadMood()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad Mood");
            string expected = "sad";
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForCustomizedNullException()

        {
            string expected = "Mood should not be NULL";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void TestMethodForCustomizedEmptyException()

        {
            string expected = "Mood should not be empty";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(string.Empty);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [TestMethod]
        public void Fordefault()
        {
            MoodAnalyser expected = new MoodAnalyser();
            object obj = null;
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyse("ModeAnalyserProject.MoodAnalyser", "MoodAnalyser");

            }
            catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }
        [TestMethod]

        public void Reflection_Return_Default_Constructor_No_Class_Found()
        {
            string expected = "Class not Found";

            try
            {

                MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProject.Mood", "Mood");

            }
            catch (CustomException ex)

            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Constructor_Found()
        {
            string expected = "Constructor not found";

            try
            {

                MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserPro.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException actual)

            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Parameterized_Constructor()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);

            try
            {

                MoodAnalyserFactory.CreateMoodAnalyserParameter("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser", message);

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }

        }
        //Invalid case
        [TestMethod]
        public void Reflection_Return_Parameterized_Class_Invalid()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            object actual = null;
            try
            {

                MoodAnalyserFactory.CreateMoodAnalyserParameter("MoodAnalyserProject.MoodAna", "MoodAnalyser", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Method()
        {
            string expected = "happy";
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod("happy", "AnalyseMood");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Reflection_Return_Invalid_Method()
        {
            string expected = "Method not found";
            try
            {

                string actual = MoodAnalyserFactory.InvokeAnalyserMethod("happy", "Analyze");
            }
            catch (CustomException e)
            {

                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}