using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {

    public string sceneName;
    public float timer;

    void Start()
    {
        if(timer > 0)
        {
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(timer);
        SwitchToScene();
    }

    public void SwitchToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
