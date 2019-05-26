using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ansver
{
    public class Reaction : MonoBehaviour
    {
        public Text reaction;
        public Character.Mediator character;
        public Enemy.Mediator enemy;
        public SceneTransitions transitions;
        public Enemy.Health enemyHP;
        public GameObject StartEndGamePanel;
        public CameraShake cameraShake;
        public TMPro.TextMeshProUGUI questionsMore;

        public void ReactCorrect()
        {
            if (!enemy.IsDie())
            {
                reaction.text = "correct";
                character.Attack();

                questionsMore.text = character.GetEnergy().ToString() + "/5"; 
            }
        }
        public void OnEnemyAttacked()
        {
            enemy.OnAttacked();
            enemyHP.OnDamage(1);

            StopAllCoroutines();

            StartCoroutine(cameraShake.Shake(.15f, .4f));

            if (enemy.IsDie())
            {
                StartCoroutine(GoToWonScene());
            }
        }
        public void ReactInorrect()
        {
            if (!character.IsGameLost())
            {
                reaction.text = "incorrect";
                enemy.Attack();
            }
        }
        public void OnCharacterAttacked()
        {
            character.OnAttacked();

            StopAllCoroutines();

            StartCoroutine(cameraShake.Shake(.15f, .4f));

            if (character.IsGameLost())
            {
                StartCoroutine(GoToLooseScene());
            }

            questionsMore.text = character.GetEnergy().ToString() + "/5";
        }

        IEnumerator GoToWonScene()
        {
            enemy.OnDie();
            yield return new WaitForSeconds(5.0f);
            StartEndGamePanel.SetActive(true);
            transitions.LoadWinScene();
        }

        IEnumerator GoToLooseScene()
        {
            character.OnLostGame();
            yield return new WaitForSeconds(5.0f);
            StartEndGamePanel.SetActive(true);
            transitions.RestartLevel();
        }
    } 
}
