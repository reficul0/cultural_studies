using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ansver
{
    public class Manager : MonoBehaviour
    {
        UIAnsver correct;
        public Reaction reaction;
        public Question.Manager manager;

        public void SetCorrectAnsver(UIAnsver correct)
        {
            this.correct = correct;
        }

        public void OnUserAnsverChoice(UIAnsver ansver)
        {
            MakeAnsverReaction(ansver);
            OnAnsverProcessed(isCorrectAnsver(ansver));
        }

        void MakeAnsverReaction(UIAnsver ansver)
        {
            if (isCorrectAnsver(ansver))
                OnCorrectAnsver();
            else
                OnIncorrectAnsver();
        }
        bool isCorrectAnsver(UIAnsver ansver)
        {
            return correct == ansver;
        }
        void OnCorrectAnsver()
        {
            reaction.ReactCorrect();
        }
        void OnIncorrectAnsver()
        {
            reaction.ReactInorrect();
        }

        void OnAnsverProcessed(bool isCorrectAnsver)
        {
            manager.OnAnsver(isCorrectAnsver);
        }
    } 
}
