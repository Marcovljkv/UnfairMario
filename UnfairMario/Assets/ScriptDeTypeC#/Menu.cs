using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            //  Set le nbMorts a 0
            PlayerPrefs.SetInt("nbMorts", 0);
            SceneManager.LoadScene("Game");
        }
    }
}