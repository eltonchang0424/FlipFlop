using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreBoard : MonoBehaviour {
    public static ScoreBoard instance;
    public Text scoreText;
    public GameObject ghostPrefab;
    public GameObject shadow;
    public Text gameOverText;
    public GameObject gameOverTextObject;
    public GameObject blackScreen;
    public Text finalScore;
    public GameObject finalScoreObject;
    public GameObject playAgainButton;
    public Button playAgainButtonPress;
    public Text playAgain;
    public GameObject menuButton;
    public Button menuButtonPress;
    public Text menu;
    public Button pauseButton;
    public Text pausedText;
    public GameObject pausedTextObject;
    public Text highScore;

    public GameObject resumeButton;
    public Button resumeButtonPress;
    public Text resumeText;
    public GameObject restartButton;
    public Button restartButtonPress;
    public Text restartText;
    public GameObject optionsButton;
    public Button optionsButtonPress;
    public Text optionsText;
    public GameObject menuPauseButton;
    public Button menuPausePress;
    public Text menuPauseText;
    public Text countdown;
    public GameObject player;
    public Button optionsMenuButton;

    public Button backMenu;
    public Button statsMenu;
    public Button statsBack;
    public Button backPause;
    public Button statsBackPause;

    private void Awake()
    {
        instance = this;
    }

	private void Start()
	{
        playAgainButtonPress.onClick.AddListener(onPlayAgainClick); 
        pauseButton.onClick.AddListener(onPauseClick); 
        resumeButtonPress.onClick.AddListener(onResumeClick); 
        restartButtonPress.onClick.AddListener(onRestartClick); 
        menuPausePress.onClick.AddListener(onMenuPausePress); 
        optionsMenuButton.onClick.AddListener(GameStateManager.instance.onOptionsMenuPress);
        backMenu.onClick.AddListener(GameStateManager.instance.onBackMenuPress);
        statsMenu.onClick.AddListener(GameStateManager.instance.onStatsPress);
        statsBack.onClick.AddListener(GameStateManager.instance.onStatsBackPress);
        optionsButtonPress.onClick.AddListener(onOptionsPausePress);
        backPause.onClick.AddListener(onBackPausePress);
    }

	public void IncrementScore()
    {
        scoreText.text = "" + (int.Parse(scoreText.text) + 1);
        if(int.Parse(scoreText.text) >= 1)
        {
            if ((int.Parse(scoreText.text) - 1) % 5 == 0 || int.Parse(scoreText.text) == 1)
            {
                GameObject newGhost = Instantiate(ghostPrefab, Player.instance.transform.position, Quaternion.identity);
                GameObject Shadow = Instantiate(shadow, newGhost.transform.position, Quaternion.identity);
                float delay = 0.5f + 0.2f * PlayerGhost.x;
                Destroy(Shadow, delay);
                newGhost.GetComponent<PlayerGhost>().delay += 0.2f * PlayerGhost.x;
                PlayerGhost.x += 1;
            }
        }
    }

    private void setFinalScore()
    {
        finalScore.text = scoreText.text;
    }

    public void FadeInGameOver()
    {
        StartCoroutine(FadeInBlackScreenScore());
    }

    public void Pause()
    {
        StartCoroutine(onPause());
    }

    public void Resume()
    {
        StartCoroutine(OnResume());
    }

    public void disablePause()
    {
        pauseButton.gameObject.SetActive(false);
    }

    public IEnumerator FadeInBlackScreenScore()
    {
        playAgainButtonPress.GetComponent<Button>().enabled = false;
        pauseButton.GetComponent<Button>().enabled = false;
        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        optionsMenuButton.GetComponent<Button>().enabled = false;
        backMenu.GetComponent<Button>().enabled = false;
        statsMenu.GetComponent<Button>().enabled = false;
        statsBack.GetComponent<Button>().enabled = false;
        backPause.GetComponent<Button>().enabled = false;
        statsBackPause.GetComponent<Button>().enabled = false;

        yield return StartCoroutine(FadeInObject(blackScreen, 0.4f, 0.5f));
        gameOverTextObject.SetActive(true);
        yield return StartCoroutine(FadeInText(gameOverText, 0.15f));
        finalScoreObject.SetActive(true);
        setFinalScore();
        yield return StartCoroutine(FadeInText(finalScore, 0.15f));
        highScore.gameObject.SetActive(true);
        if(int.Parse(finalScore.text) > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", int.Parse(finalScore.text));
            highScore.text = "NEW HIGH SCORE";
        }
        else
        {
            highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore");
        }
        yield return StartCoroutine(FadeInText(highScore, 0.15f));
        playAgainButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(playAgainButtonPress, 0.15f));
        yield return StartCoroutine(FadeInText(playAgain, 0.15f));
        menuButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(menuButtonPress, 0.15f));
        yield return StartCoroutine(FadeInText(menu, 0.15f));
        playAgainButton.GetComponent<Button>().enabled = true;
        menuButton.GetComponent<Button>().enabled = true;
    }

    public IEnumerator onPause()
    {
        playAgainButtonPress.GetComponent<Button>().enabled = false;
        pauseButton.GetComponent<Button>().enabled = false;
        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        optionsMenuButton.GetComponent<Button>().enabled = false;
        backMenu.GetComponent<Button>().enabled = false;
        statsMenu.GetComponent<Button>().enabled = false;
        statsBack.GetComponent<Button>().enabled = false;
        backPause.GetComponent<Button>().enabled = false;
        statsBackPause.GetComponent<Button>().enabled = false;

        Player.instance.playerVelPause = Player.instance.rb.velocity;

        yield return StartCoroutine(FadeInObject(blackScreen, 0.4f, 0.25f));
        pausedTextObject.SetActive(true);
        yield return StartCoroutine(FadeInText(pausedText, 0.1f));
        resumeButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(resumeButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(resumeText, 0.1f));
        restartButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(restartButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(restartText, 0.1f));
        optionsButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(optionsButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(optionsText, 0.1f));
        menuPauseButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(menuPausePress, 0.1f));
        yield return StartCoroutine(FadeInText(menuPauseText, 0.1f));
        resumeButtonPress.GetComponent<Button>().enabled = true;
        restartButtonPress.GetComponent<Button>().enabled = true;
        optionsButtonPress.GetComponent<Button>().enabled = true;
        menuPausePress.GetComponent<Button>().enabled = true;
    }

    private void onBackPausePress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(GameStateManager.instance.unspawnOptionsPause());
        StartCoroutine(spawnPause());
    }

    public IEnumerator spawnPause()
    {
        playAgainButtonPress.GetComponent<Button>().enabled = false;
        pauseButton.GetComponent<Button>().enabled = false;
        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        optionsMenuButton.GetComponent<Button>().enabled = false;
        backMenu.GetComponent<Button>().enabled = false;
        statsMenu.GetComponent<Button>().enabled = false;
        statsBack.GetComponent<Button>().enabled = false;
        backPause.GetComponent<Button>().enabled = false;
        statsBackPause.GetComponent<Button>().enabled = false;

        pausedTextObject.SetActive(true);
        yield return StartCoroutine(FadeInText(pausedText, 0.1f));
        resumeButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(resumeButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(resumeText, 0.1f));
        restartButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(restartButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(restartText, 0.1f));
        optionsButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(optionsButtonPress, 0.1f));
        yield return StartCoroutine(FadeInText(optionsText, 0.1f));
        menuPauseButton.SetActive(true);
        yield return StartCoroutine(FadeInButton(menuPausePress, 0.1f));
        yield return StartCoroutine(FadeInText(menuPauseText, 0.1f));
        resumeButtonPress.GetComponent<Button>().enabled = true;
        restartButtonPress.GetComponent<Button>().enabled = true;
        optionsButtonPress.GetComponent<Button>().enabled = true;
        menuPausePress.GetComponent<Button>().enabled = true;
    }

    public IEnumerator OnResume()
    {
        playAgainButtonPress.GetComponent<Button>().enabled = false;
        pauseButton.GetComponent<Button>().enabled = false;
        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        optionsMenuButton.GetComponent<Button>().enabled = false;
        backMenu.GetComponent<Button>().enabled = false;
        statsMenu.GetComponent<Button>().enabled = false;
        statsBack.GetComponent<Button>().enabled = false;
        backPause.GetComponent<Button>().enabled = false;
        statsBackPause.GetComponent<Button>().enabled = false;

        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        pausedText.color = new Color(pausedText.color.r, pausedText.color.g, pausedText.color.b, 0);
        pausedTextObject.SetActive(false);
        resumeText.color = new Color(resumeText.color.r, resumeText.color.g, resumeText.color.b, 0);
        resumeButton.SetActive(false);
        restartText.color = new Color(restartText.color.r, restartText.color.g, restartText.color.b, 0);
        restartButton.SetActive(false);
        optionsText.color = new Color(optionsText.color.r, optionsText.color.g, optionsText.color.b, 0);
        optionsButton.SetActive(false);
        menuPauseText.color = new Color(menuPauseText.color.r, menuPauseText.color.g, menuPauseText.color.b, 0);
        menuPauseButton.SetActive(false);
        countdown.gameObject.SetActive(true);
        yield return StartCoroutine(ResumeCountdown());
        countdown.gameObject.SetActive(false);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(blackScreen.GetComponent<SpriteRenderer>().color.r, blackScreen.GetComponent<SpriteRenderer>().color.g, blackScreen.GetComponent<SpriteRenderer>().color.b, 0);
        pauseButton.gameObject.SetActive(true);
        pauseButton.gameObject.GetComponent<Button>().enabled = true;

        Player.instance.rb.velocity = Player.instance.playerVelPause;

        GameStateManager.instance.Resume();
    }

    public IEnumerator unspawnPauseMenu()
    {
        playAgainButtonPress.GetComponent<Button>().enabled = false;
        pauseButton.GetComponent<Button>().enabled = false;
        resumeButtonPress.GetComponent<Button>().enabled = false;
        restartButtonPress.GetComponent<Button>().enabled = false;
        optionsButtonPress.GetComponent<Button>().enabled = false;
        menuPausePress.GetComponent<Button>().enabled = false;
        optionsMenuButton.GetComponent<Button>().enabled = false;
        backMenu.GetComponent<Button>().enabled = false;
        statsMenu.GetComponent<Button>().enabled = false;
        statsBack.GetComponent<Button>().enabled = false;
        backPause.GetComponent<Button>().enabled = false;
        statsBackPause.GetComponent<Button>().enabled = false;

        yield return StartCoroutine(GameStateManager.instance.FadeOutText(pausedText, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutText(resumeText, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutButton(resumeButtonPress, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutText(restartText, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutButton(restartButtonPress, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutText(optionsText, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutButton(optionsButtonPress, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutText(menuPauseText, 0.05f));
        yield return StartCoroutine(GameStateManager.instance.FadeOutButton(menuButtonPress, 0.05f));

        pausedTextObject.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        optionsButton.SetActive(false);
        menuPauseButton.SetActive(false);
    }

    public IEnumerator optionsPausePress()
    {
        yield return StartCoroutine(unspawnPauseMenu());
        yield return StartCoroutine(GameStateManager.instance.onOptionsPause());
    }

    private void onOptionsPausePress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(optionsPausePress());
    }

    public IEnumerator FadeInObject(GameObject obj, float targetAlpha, float time)
    {
        obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, obj.GetComponent<SpriteRenderer>().color.a);

            while (obj != null && obj.GetComponent<SpriteRenderer>().color.a < targetAlpha)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, obj.GetComponent<SpriteRenderer>().color.a + 0.02f / time);
                yield return new WaitForSecondsRealtime(0.02f);
            }

    }

    public IEnumerator FadeInText(Text text, float time)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (0.02f / time));
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    public IEnumerator FadeInButton(Button button, float time)
    {
        button.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        while (button.GetComponent<Image>().color.a < 0.04f)
        {
            button.GetComponent<Image>().color = new Color(255, 255, 255, button.GetComponent<Image>().color.a + .02f / time);
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    private IEnumerator FadeInButtonFull(Button button, float time)
    {
        button.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        while (button.GetComponent<Image>().color.a < 1)
        {
            button.GetComponent<Image>().color = new Color(255, 255, 255, button.GetComponent<Image>().color.a + 0.04f / time);
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }

    private IEnumerator ResumeCountdown()
    {
        countdown.text = "4";
        while (int.Parse(countdown.text) != 1)
        {
            countdown.text = (int.Parse(countdown.text) - 1).ToString();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void onPlayAgainClick()
    {
        CarryOver.instance.restart = true;
        GameStateManager.instance.GameOver();
    }

    private void onPauseClick()
    {
        SoundEffects.instance.playSound("click");
        pauseButton.gameObject.SetActive(false);
        GameStateManager.instance.Pause();
        Pause();
    }

    private void onResumeClick()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(OnResume());
    }

    private void onRestartClick()
    {
        CarryOver.instance.restart = true;
        GameStateManager.instance.GameOver();
    }

    private void onMenuPausePress()
    {
        CarryOver.instance.restart = false;
        GameStateManager.instance.GameOver();
    }

}
