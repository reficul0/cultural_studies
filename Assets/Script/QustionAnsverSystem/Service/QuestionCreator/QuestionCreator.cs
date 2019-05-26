using System.Diagnostics;

namespace Service
{
    public class QuestionCreator
    {
        [Conditional("DEBUG")]
        public static void CreateQuestionsBinaryFileFromXML()
        {
            XMLQuestionsLoader loader = new XMLQuestionsLoader();
            QuestionStruct[] questions = loader.Load();

            BinaryQuestionsSaver saver = new BinaryQuestionsSaver(questions);
            saver.Save();
        }
    } 
}
