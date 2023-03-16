using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public AudioSource audio;

    public void startGame()
    {
        SceneManager.LoadScene(2);
    //    audio.Play();
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!!!!!");
     //   audio.Play();
    }

    public void tryAgain()
    {
        Debug.Log("Load Previous scene!!!!!");
    }
    public void buttonSound()
    {
        audio.Play();
    }
}
