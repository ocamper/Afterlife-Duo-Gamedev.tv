using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] private Animator anim;


    public IEnumerator activateOut()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        anim.SetTrigger("transIn");
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void activateTime()
    {
        Time.timeScale = 1;
    }
}
