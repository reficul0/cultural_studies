using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Mediator : MonoBehaviour
    {
        [SerializeField] Structure character;
        public Animator animator;

        public void Attack()
        {
            animator.PlayAttack();
        }

        public void OnAttacked()
        {
            animator.PlayAttacked();
        }

        public void OnLostGame()
        {
            animator.PlayLostGame();
        }
    } 
}
