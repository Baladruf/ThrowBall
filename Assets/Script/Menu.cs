using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour {

    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI lastScore;

    private void Awake()
    {
        bestScore.text = "Meilleur Score : " + PlayerPrefs.GetInt("BestScore", 0);
        lastScore.text = "Dernier Score : " + PlayerPrefs.GetInt("LastScore", 0);
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
