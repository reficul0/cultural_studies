using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Service;

namespace Question
{
    public class Manager : MonoBehaviour
    {
        public Setter creator;

        Loader loader;
        Thread loaderThread;

        Queue<QuestionStruct> questions = new Queue<QuestionStruct>();

        void LoadQuestions()
        {
            InitializeLoader();
            StartLoaderThread();
        }
        void InitializeLoader()
        {
            loader = new Loader(this);
        }
        void StartLoaderThread()
        {
            loaderThread = new Thread(new ThreadStart(loader.OnLoadQuestions));
            loaderThread.Start();
        }

        public void OnQuestionAdd(QuestionStruct question)
        {
            AddQuestion(question);
        }
        void AddQuestion(QuestionStruct question)
        {
            lock (questions)
            {
                questions.Enqueue(question);
            }
        }

        public void OnAnsver(bool isCorrectAnsver)
        {
            if (isCorrectAnsver)
                OnCorrectAnsver();
            else
                OnIncorrectAnsver();
        }
        void OnCorrectAnsver()
        {
            GoToNextQuestion();
        }
        void OnIncorrectAnsver()
        {
            GoToNextQuestion();
        }
        void GoToNextQuestion()
        {
            SetNextQuestion();
        }
        void SetNextQuestion()
        {
            lock (questions)
            {
                creator.SetQuestion(questions.Dequeue());
            }
        }

        private void Start()
        {
            Service.QuestionCreator.CreateQuestionsBinaryFileFromXML();
            LoadQuestions();
        }
    }

}