using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance = null;

    public Score score;
    public SceneFader scenefader;
    public string nextLevel = "Level02";
    public string mainmenu = "MainMenu";
    public bool isOver = false;

    public GameObject scoreCanvas;
    public GameObject levelWonCanvas;
    public GameObject jumpScare;
    public GameObject gameOver;
    public GameObject pauseCanvas;

    public Text scoreTextGameOver;
    public Text scoreTextLevelWon;

    [SerializeField]
    public Image images;

    string dataPath;



    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != null)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        dataPath = universalContainer.url;

        if (File.Exists(dataPath))
        {
            byte[] imageData = File.ReadAllBytes(dataPath);
            Texture2D tex = new Texture2D(1, 1);
            tex.LoadImage(imageData);

            Sprite S_tex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
            images.sprite = S_tex;
        }
        else
        {
            Debug.Log("File does not exist");
        }

    }

    public IEnumerator Activate()
    {
        isOver = true;
        jumpScare.SetActive(true);
        yield return new WaitForSeconds(5);
        jumpScare.SetActive(false);
        scoreCanvas.SetActive(false);
        gameOver.SetActive(true);
    }


    //Button Stuff
    public void Retry()
    {
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void LevelComplete()
    {
        levelWonCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
    }
    public void NextLevel()
    {
        scenefader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        scenefader.FadeTo(mainmenu);
    }

    private void Update()
    {
        scoreTextGameOver.text = "SCORE : " +score.GetPointScore().ToString();
        scoreTextLevelWon.text = "SCORE : " + score.GetPointScore().ToString();

        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) )&& isOver==false)
        {
                if(Time.timeScale == 1.0)
            {
                Time.timeScale = 0.0f;
                pauseCanvas.SetActive(true);
                score.isRun = false;
                
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseCanvas.SetActive(false);
                score.isRun = true;
            }
            
        }
    }
    public void RetryPaused()
    {
        Time.timeScale = 1.0f;
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void MenuPaused()
    {
        Time.timeScale = 1.0f;
        scenefader.FadeTo("MainMenu");
    }

}
