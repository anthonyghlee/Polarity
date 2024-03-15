using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void QuitGame()
    {
        //Application.Quit();
        //I'm afraid that if we use this command that it won't work
        // the tutorial uses unity build like as a file, not on itch
    }

}
