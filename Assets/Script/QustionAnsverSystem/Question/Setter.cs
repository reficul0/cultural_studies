using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Question
{
    public class Setter : MonoBehaviour
    {
        public Text question;

        public Text leftUp;
        public Text leftDown;
        public Text rightUp;
        public Text rightDown;

        Ansver.Manager manager;

        public void SetQuestion(QuestionStruct creating)
        {
            SetGUIQuestion(creating);
        }
        void SetGUIQuestion(QuestionStruct creating)
        {
            question.text = creating.text;

            leftUp.text = creating.options.leftUp;
            leftDown.text = creating.options.leftDown;
            rightUp.text = creating.options.rightUp;
            rightDown.text = creating.options.rightDown;

            manager.SetCorrectAnsver(creating.correct);
        }

        void Start()
        {
            if (manager == null)
                InitializeManager();
        }
        void InitializeManager()
        {
            manager = FindObjectOfType<Ansver.Manager>();
        }
    } 
}
