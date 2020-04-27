using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

   


    public void LoadGame()
    {
        SceneManager.LoadScene("Gameplay");
      
        
    }

    
    public void GoBack()
    {
        SceneManager.LoadScene("Start");
       
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("End");
    }

   public void Exit()
    {
        Application.Quit();
    }



}
