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
            OnAnsverProcessed(IsCorrectAnsver(ansver));
        }

        void MakeAnsverReaction(UIAnsver ansver)
        {
            if (IsCorrectAnsver(ansver))
                OnCorrectAnsver();
            else
                OnIncorrectAnsver();
        }
        bool IsCorrectAnsver(UIAnsver ansver)
        {
#if DEBUG
            return correct != null ? correct.number == ansver.number
                                   : false;
#else
            return correct.number == ansver.number;
#endif
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
