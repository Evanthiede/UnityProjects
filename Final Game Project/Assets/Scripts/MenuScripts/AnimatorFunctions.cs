using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip whichSound)
    {
        if(!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            disableOnce = false;
        }
    }
    void sceneSwitch(string nextSceneName)
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
        Debug.Log("teleport");
    }
    void options()
    {
        Debug.Log("Options");
    }
    void quitGame()
    {
        Application.Quit();
    }
}
