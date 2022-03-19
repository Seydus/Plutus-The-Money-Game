using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance;

    [SerializeField] private Animator animSceneTransition;
    [SerializeField] private Animator animSceneTransition2;
    [SerializeField] private Animator pauseTransition;
    [SerializeField] private GameObject pauseTabObject;
    [SerializeField] private GameObject pauseObject;

    [SerializeField] private GameObject[] instructions;

    public bool stopUpdate;
    public int level;

    public void Awake()
    {
        Instance = this;
        stopUpdate = false;
    }

    public void MouseClick(string name)
    {
        switch (name)
        {
            case "Menu":
                StartCoroutine(StartTransition());
                break;
            case "Continue":
                pauseTransition.SetBool("isEndPause", true);
                pauseTransition.SetBool("isStartPause", false);
                pauseObject.SetActive(false);
                pauseTabObject.SetActive(true);
                Time.timeScale = 1f;
                break;
            case "Pause":
                pauseTransition.SetBool("isEndPause", false);
                pauseTransition.SetBool("isStartPause", true);
                pauseObject.SetActive(true);
                pauseTabObject.SetActive(false);
                Time.timeScale = 0f;
                break;
            case "Restart":
                StartCoroutine(RestartTransition());
            break;
        }
    }

    #region Instructions
    public IEnumerator Instructions()
    {
        instructions[level].SetActive(true);
        yield return new WaitForSeconds(2f);

        instructions[level].SetActive(false);
        stopUpdate = false;
    }

    public void IntrctuctionsOpen()
    {
        StartCoroutine(Instructions());
    }
    #endregion

    #region  Transition
    public IEnumerator StartTransition()
    {
        animSceneTransition2.SetTrigger("endTransition");
        yield return new WaitForSecondsRealtime(1.5f);
        
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    public IEnumerator RestartTransition()
    {
        animSceneTransition2.SetTrigger("endTransition");
        yield return new WaitForSecondsRealtime(1.5f);
        
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }
    #endregion
}
