using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Animator : MonoBehaviour
    {
        UnityEngine.Animator animator;

        void Start()
        {
            animator = GetComponent<UnityEngine.Animator>();
        }

        public void PlayAttack()
        {
            animator.Play("Attack");
        }

        public void PlayAttacked()
        {
            animator.Play("Attacked");
        }

        public void PlayLostGame()
        {
            animator.Play("LostGame");
        }
    } 
}
