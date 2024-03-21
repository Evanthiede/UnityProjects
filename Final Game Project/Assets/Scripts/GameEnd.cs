using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public void FinishGame()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
        Debug.Log("Ended");
    }
}
