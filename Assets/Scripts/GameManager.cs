using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Slider fuel;
    public Image GameOverImg;
    public Text GameOverTxt;


     public bool saved = false;

    // Start is called before the first frame update
    void Start()
    {
        GameOverImg.enabled = false;
        GameOverTxt.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel.value == 0)
        {
            GameOver();
        }

        if (saved == true)
            SceneManager.LoadScene(3);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverImg.enabled = true;
        GameOverTxt.enabled = true;
    }

    public void Pause() 
    {
        Time.timeScale = 0;

    }

    public void ContinueGame()
    {
        Time.timeScale = 1;

    }

}
