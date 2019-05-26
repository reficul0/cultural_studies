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
            DecreaseEnergy();
        }
        public void OnAttacked()
        {
            animator.PlayAttacked();
            DecreaseEnergy();
        }
        void DecreaseEnergy()
        {
            --character.energy;
        }

        public int GetEnergy()
        {
            return character.energy;
        }

        public bool IsGameLost()
        {
            return character.energy <= 0;
        }
        public void OnLostGame()
        {
            animator.PlayLostGame();
        }

        void Start()
        {
            character = Factory.Create();
        }
    } 
}
