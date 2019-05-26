using UnityEngine;

namespace Enemy
{
    public class Mediator : MonoBehaviour
    {
        [SerializeField] Structure enemy;
        public Animator animator;

        public void Attack()
        {
            animator.PlayAttack();
            //DecreaseHP();
        }
        public void OnAttacked()
        {
            animator.PlayAttacked();
            DecreaseHP();
        }
        void DecreaseHP()
        {
            --enemy.hp;
        }

        public bool IsDie()
        {
            return enemy.hp <= 0;
        }
        public void OnDie()
        {
            animator.PlayDie();
        }

        void Start()
        {
            enemy = Factory.Create();
        }
    } 
}
