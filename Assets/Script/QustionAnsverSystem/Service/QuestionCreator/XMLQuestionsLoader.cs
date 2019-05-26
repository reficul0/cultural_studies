using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Service
{
    public class XMLQuestionsLoader
    {
        private readonly string questionsFile = Application.dataPath + "/questions.xml";

        public static void ReadQuestion(XmlTextReader reader, QuestionStruct que)
        {
            que.correct.number = Convert.ToUInt32(reader.GetAttribute("correct"));
            que.text = reader.GetAttribute("text");
            que.options.leftUp = reader.GetAttribute("leftUp");
            que.options.leftDown = reader.GetAttribute("leftDown");
            que.options.rightUp = reader.GetAttribute("rightUp");
            que.options.rightDown = reader.GetAttribute("rightDown");
        }

        static void CheckStartingElement(XmlTextReader reader, string name, bool readData)
        {
            if (readData)
            {
                ReadDataFromXml(reader);
            }

            if (reader.NodeType != XmlNodeType.Element)
                XmlError(reader, string.Format("Ожидался элемент {0}, а обнаружен элемент {1}", name, reader.NodeType));

            if (!reader.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                XmlError(reader, string.Format("Ожидался элемент {0}, а обнаружен элемент {1}", name, reader.Name));
        }
        static void CheckEndingElement(XmlTextReader reader)
        {
            ReadDataFromXml(reader);

            if (reader.NodeType != XmlNodeType.EndElement)
                XmlError(reader, string.Format("Ожидалось закрытие элемента, а обнаружен элемент {0} - {1}", reader.NodeType, reader.Name));
        }

        static void XmlError(XmlTextReader reader, string message)
        {
            Debug.LogError(string.Format("Строка {0}. {1}", reader.LineNumber.ToString(), message));
        }
        static void ReadDataFromXml(XmlTextReader reader)
        {
            do
            {
                reader.Read();
            } while ((reader.NodeType == XmlNodeType.Whitespace) || (reader.NodeType == XmlNodeType.Comment));
        }




        internal QuestionStruct[] Load()
        {
            XmlTextReader reader = new XmlTextReader(questionsFile);
            CheckStartingElement(reader, "Questions", true);

            if (reader.IsEmptyElement)
                return new QuestionStruct[0];

            Queue<QuestionStruct> questions = new Queue<QuestionStruct>();

            ReadDataFromXml(reader);
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                QuestionStruct question = new QuestionStruct();

                CheckStartingElement(reader, "Question", false);
                ReadQuestion(reader, question);

                if (!reader.IsEmptyElement)
                    CheckEndingElement(reader);

                ReadDataFromXml(reader);

                questions.Enqueue(question);
            }

            return questions.ToArray();
        }
    }
}