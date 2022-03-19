using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public static MenuUIController Instance;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;

    public Animator anim;
    public Animator animSceneTransition;

    private void Awake()
    {
        Instance = this;
    }

    public void MouseClick(string name)
    {
        switch (name)
        {
            case "Play":
                StartCoroutine(StartTransition());
                break;
            case "Settings":
                // menu.SetActive(false);
                // settings.SetActive(true);
                anim.SetBool("isMenu", false);
                anim.SetBool("isSettings", true);
                break;
            case "Back":
                // menu.SetActive(true);
                // settings.SetActive(false);
                anim.SetBool("isMenu", true);
                anim.SetBool("isSettings", false);
                break;
        }
    }
    public void SocialMediasMouseClick(string name)
    {
        switch(name)
        {
            case "Youtube":
            Application.OpenURL("https://www.youtube.com/channel/UCmOih5Bfe32Nq2gzGmtvoSg");
            break;
            case "Twitter":
            Application.OpenURL("https://twitter.com/saidusdev");
            break;
            case "Facebook":
            Application.OpenURL("https://web.facebook.com/carlvincent.kho/");
            break;
            case "Notion":
            Application.OpenURL("https://www.notion.so/carlkho/Carl-Achievements-Tracker-e296d985f1ee4bd2881e256d45bae39b");
            break;
            case "Instagram":
            Application.OpenURL("https://www.instagram.com/cvk.o_o/");
            break;
            case "Pinterest":
            Application.OpenURL("https://www.patreon.com/saidus?fan_landing=true");
            break;
        }
    }
    public IEnumerator StartTransition()
    {
        animSceneTransition.SetTrigger("endTransition");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
}
