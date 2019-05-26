using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;

    public void RestartLevel()
    {
        StopAllCoroutines();
        StartCoroutine(LoadLooseScene());
    }

    public void LoadNextScene()
    {
        StopAllCoroutines();
        StartCoroutine(_LoadNextScene());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadWinScene()
    {
        StopAllCoroutines();
        StartCoroutine(_LoadWinScene());
    }

    IEnumerator _LoadNextScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLooseScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(4);
    }
    IEnumerator _LoadWinScene()
    {
        transitionAnim.SetTrigger("won");
        yield return new WaitForSeconds(4);
    }
    public void GoToMenue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
