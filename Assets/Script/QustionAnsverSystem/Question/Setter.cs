using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Question
{
    public class Setter : MonoBehaviour
    {
        public TextMeshProUGUI question;

        public TextMeshProUGUI leftUp;
        public TextMeshProUGUI leftDown;
        public TextMeshProUGUI rightUp;
        public TextMeshProUGUI rightDown;

        Ansver.CManager manager;

        public void SetQuestion(QuestionStruct creating)
        {
            SetGUIQuestion(creating);
        }
        void SetGUIQuestion(QuestionStruct creating)
        {
            ResetTextBoxes();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(creating));

            manager.SetCorrectAnsver(creating.correct);
        }

        IEnumerator TypeSentence(QuestionStruct creating)
        {
            yield return new WaitForSeconds(.5f);

            var textBox = question;
            var text = creating.text;
            foreach (var letter in text.ToCharArray())
            {
                textBox.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.4f);

            textBox = leftUp;
            text = creating.options.leftUp;
            foreach (var letter in text.ToCharArray())
            {
                textBox.text += letter;
                yield return new WaitForSeconds(0.01f);
            }
            
            yield return new WaitForSeconds(0.4f);

            textBox = leftDown;
            text = creating.options.leftDown;
            foreach (var letter in text.ToCharArray())
            {
                textBox.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.4f);

            textBox = rightUp;
            text = creating.options.rightUp;
            foreach (var letter in text.ToCharArray())
            {
                textBox.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.4f);

            textBox = rightDown;
            text = creating.options.rightDown;
            foreach (var letter in text.ToCharArray())
            {
                textBox.text += letter;
                yield return new WaitForSeconds(0.01f);
            }
        }

        void ResetTextBoxes()
        {
            question.text = "";

            leftUp.text = "";
            leftDown.text = "";
            rightUp.text = "";
            rightDown.text = "";
        }

        void Start()
        {
            if (manager == null)
                InitializeManager();
        }
        void InitializeManager()
        {
            manager = FindObjectOfType<Ansver.CManager>();
        }
    } 
}
