using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MortsMenu : MonoBehaviour
{
    public TextMesh label;
    float delay = 3; // en secondes


    void Start()
    {
        //  Ecrit sur le label le nombre de morts
        label.text = "x " + PlayerPrefs.GetInt("nbMorts").ToString();
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}