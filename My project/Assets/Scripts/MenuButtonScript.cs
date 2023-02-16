using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void PlayButton() 
    {
        SceneManager.LoadScene(""); //alko scenen nimi tähän
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
