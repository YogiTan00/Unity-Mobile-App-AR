using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeMenu : MonoBehaviour
{
    public GameObject oMainM;
    public GameObject oAboutM;
    public GameObject oPlayM;
    public GameObject oPlayE;

    public void AboutMenu()
    {
        oAboutM.SetActive(true);
        oMainM.SetActive(false);
    }

    public void PlayEko()
    {
        oPlayE.SetActive(true);
        oPlayM.SetActive(false);
    }

    public void PlayMenu()
    {
        oPlayM.SetActive(true);
        oPlayE.SetActive(false);
    }

    public void BackMain()
    {
        oMainM.SetActive(true);
        oAboutM.SetActive(false);
    }

    public void oMenu(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void ExitBut()
    {
        Application.Quit();
        Debug.Log("Quit...");
    }
}
