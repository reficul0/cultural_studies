using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Question
{
    public class Manager : MonoBehaviour
    {
        public Setter creator;

        Loader loader;
        Thread loaderThread;
        bool isInitialQuestionNotSet = true;
        bool isSceneLoaded = false;
        public GameObject objectToOff;
        public Character.Mediator character;
        public Enemy.Mediator enemy;

        Queue<QuestionStruct> questions = new Queue<QuestionStruct>();

        public void OnSceneLoaded()
        {
            if (isInitialQuestionNotSet)
            {
                objectToOff.SetActive(false);
                isSceneLoaded = true;
            }

        }

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
            loaderThread = new Thread(new ThreadStart(loader.OnLoad));
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
        bool IsInitialQuestionReadyToSet()
        {
            return isSceneLoaded && isInitialQuestionNotSet && HasAnyQuestion();
        }
        void SetInitialQuestion()
        {
            SetNextQuestion();
            isInitialQuestionNotSet = false;
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
            if(!character.IsGameLost() && !enemy.IsDie())
                SetNextQuestion();
        }
        void SetNextQuestion()
        {
            lock (questions)
            {
                if ( HasAnyQuestion() )
                    creator.SetQuestion(questions.Dequeue());
            }
        }
        bool HasAnyQuestion()
        {
            return questions.Count != 0;
        }

        private void Start()
        {
            Service.QuestionCreator.CreateQuestionsBinaryFileFromXML();
            LoadQuestions();
        }
        private void Update()
        {
            if (IsInitialQuestionReadyToSet())
                SetInitialQuestion();
        }
    }

}