using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changescene : MonoBehaviour {
    public void Change(string SceneName)
    {
        if(SceneName=="Esc")
            Application.Quit();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);

    }
}
