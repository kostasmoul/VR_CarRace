using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

	public void restartGame()
    {
        Debug.Log("restart game option selected");
        SceneManager.LoadScene("CityScene");
    }
    public void quitGame()
    {
        Debug.Log("quit game option selected");
        Application.Quit();
    }
}
