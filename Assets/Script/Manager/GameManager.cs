using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Component")]
    [SerializeField] CameraEffect cameraEffect;
    [SerializeField] TextMeshProUGUI modeUI;
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] TextMeshProUGUI scoreUI;

    [Header("Tweak")]
    [SerializeField] float gameDuration = 3;
    [SerializeField] float multiplierSinus = 1.5f;
    [SerializeField] float multiplierInverse = 2;

    public static GameManager Instance;

    private TargetManager targetManager;
    private float timer;
    private int score;
    private float multiplier = 1;

    private Coroutine timerCameraEffect = null;

    public float Score
    {
        get { return score; }
        set
        {
            score += (int)(value * multiplier);
            scoreUI.text = "Score : " + score;
        }
    }

    public string GetTimerFormat
    {
        get
        {
            string minute = (int)(timer / 60) + "' ";
            string seconde;
            if (timer % 60 < 10)
            {
                seconde = "0"+(int)(timer % 60) + "''";
            }
            else
            {
                seconde = (int)(timer % 60) + "''";
            }

            return minute + seconde;
        }
    }

    private void Awake()
    {
        Debug.Assert(gameDuration > 0);
        Instance = this;
        targetManager = GetComponent<TargetManager>();
        targetManager.Initialize();
        score = 0;
        timer = gameDuration * 60;
        timerCameraEffect = StartCoroutine(EffectCamera(true));
    }

    private void Update()
    {


        timer = Mathf.Max(0, timer - Time.deltaTime);
        timerUI.text = "Temps restant :" + GetTimerFormat;
        if (timer == 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        if(timerCameraEffect != null)
        {
            StopCoroutine(timerCameraEffect);
        }
        PlayerPrefs.SetInt("LastScore", score);
        if(score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        SceneManager.LoadScene("Scenes/Menu");
    }

    private IEnumerator EffectCamera(bool _sin)
    {
        yield return new WaitForSeconds(60);
        if (_sin)
        {
            modeUI.text = "Mode Bourré";
            multiplier = multiplierSinus;
            cameraEffect.SetSinus = true;
            yield return new WaitForSeconds(30);
            cameraEffect.SetSinus = false;
        }
        else
        {
            modeUI.text = "Mode Inversé";
            multiplier = multiplierInverse;
            cameraEffect.SetInverse = true;
            yield return new WaitForSeconds(30);
            cameraEffect.SetInverse = false;
        }
        modeUI.text = "Mode Normale";
        multiplier = 1;
        timerCameraEffect = StartCoroutine(EffectCamera(!_sin));
    }
}
