using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Service
{
    public class BinaryQuestionsSaver : MonoBehaviour
    {
        string questionsFile = Question.Loader.questionsFile;
        QuestionStruct[] questions;

        public BinaryQuestionsSaver(QuestionStruct[] questions)
        {
            this.questions = questions;
        }

        public void Save()
        {
            SaveToBinaryFile();
        }
        void SaveToBinaryFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(questionsFile, FileMode.Create);

            formatter.Serialize(stream, questions);

            stream.Close();
        }
    }
}