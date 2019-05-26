using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Question
{
    public class Loader
    {
        public Manager questionsDestination;
        public static string questionsFile = Application.dataPath + "/questions.txt";
        QuestionStruct[] questionsCache = new QuestionStruct[0];

        public Loader(Manager questionsDestination)
        {
            this.questionsDestination = questionsDestination;
        }

        public void OnLoad()
        {
            if (IsQuestionsFileExists())
                Load();
            else
                LogQuestionsFileNotFound();

            CleanUpCache();
        }

        bool IsQuestionsFileExists()
        {
            return File.Exists(questionsFile);
        }
        void LogQuestionsFileNotFound()
        {
            Debug.LogError("Questions File not found in" + questionsFile);
        }

        void Load()
        {
            LoadFromBinaryFile();
            OnLoaded();
        }
        void LoadFromBinaryFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(questionsFile, FileMode.Open);

            QuestionStruct[] loadedQuestions = formatter.Deserialize(stream) as QuestionStruct[];
            this.questionsCache = loadedQuestions;

            stream.Close();
        }

        void OnLoaded()
        {
            foreach (var question in questionsCache)
                OnQuestionLoaded(question);
        }
        void OnQuestionLoaded(QuestionStruct question)
        {
            questionsDestination.OnQuestionAdd(question);
        }

        void CleanUpCache()
        {
            questionsCache = new QuestionStruct[0];
        }
    } 
}

