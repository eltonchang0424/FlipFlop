using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

	public Button play;
    public Text playText;
    public GameObject background;
    public Button options;
    public Text optionsText;
    public Button pause;
    public Text title;
    public Button menu;
    public Button menuPause;
    public GameObject point;
    public GameObject player;
    public GameObject upArrow;
    public GameObject blackScreen;
    public Text optionsTitle;
    public Text music;
    public Slider musicSlider;
    public Text sfx;
    public Slider sfxSlider;
    public Text stats;
    public Button statsButton;
    public Text back;
    public Button backButton;

    public Text statsTitle;
    public Text totalDeaths;
    public Text totalDeathsValue;
    public Text totalPoints;
    public Text totalPointsValue;
    public Text averagePoints;
    public Text averagePointsValue;
    public Text highScore;
    public Text highScoreValue;
    public Text maxGhosts;
    public Text maxGhostsValue;
    public Text totalGhosts;
    public Text totalGhostsValue;
    public Button statsBack;
    public Text statsBackText;
    public Button backPause;
    public Text backPauseText;
    public Button statsPause;
    public Text statsPauseText;
    public Button statsBackPause;
    public Text statsBackPauseText;

    public static GameStateManager instance;

    private void Start()
    {
        Screen.SetResolution(1440, 2560, false);
        play.onClick.AddListener(onPlayPress);
        menu.onClick.AddListener(onMenuPress);
        statsPause.onClick.AddListener(onStatsPausePress);
        statsBackPause.onClick.AddListener(onStatsBackPausePress);
        sfxSlider.onValueChanged.AddListener(SoundEffects.instance.onSFXVolumeChange);
        musicSlider.onValueChanged.AddListener(SoundEffects.instance.onMusicVolumeChange);
    }

    public IEnumerator onPlay()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;
        options.gameObject.GetComponent<Button>().enabled = false;

        Player.instance.StartCoroutine(Player.instance.SwitchDir());

        player.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
        background.GetComponent<Rigidbody2D>().gravityScale = 300;
        yield return StartCoroutine(FadeOutText(title, 0.1f));
        yield return StartCoroutine(FadeOutText(playText, 0.1f));
        yield return StartCoroutine(FadeOutButton(play, 0.1f));
        yield return StartCoroutine(FadeOutText(optionsText, 0.1f));
        yield return StartCoroutine(FadeOutButton(options, 0.1f));
        title.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        point.SetActive(true);
        upArrow.SetActive(false);
        pause.gameObject.GetComponent<Button>().enabled = true;
    }

    public IEnumerator unspawnMenu()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(FadeOutText(title, 0.1f));
        yield return StartCoroutine(FadeOutText(playText, 0.1f));
        yield return StartCoroutine(FadeOutButton(play, 0.1f));
        yield return StartCoroutine(FadeOutText(optionsText, 0.1f));
        yield return StartCoroutine(FadeOutButton(options, 0.1f));
        title.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
    }

    public IEnumerator onOptionsMenu()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(unspawnMenu());
        optionsTitle.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        statsButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInObject(blackScreen, 0.4f, 0.5f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(optionsTitle, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(music, 0.1f));
        musicSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(sfx, 0.1f));
        sfxSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsButton, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(stats, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(backButton, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(back, 0.1f));
        statsButton.gameObject.GetComponent<Button>().enabled = true;
        backButton.gameObject.GetComponent<Button>().enabled = true;
        musicSlider.gameObject.GetComponent<Slider>().enabled = true;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = true;
    }

    public IEnumerator onOptionsPause()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        optionsTitle.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        statsPause.gameObject.SetActive(true);
        backPause.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInObject(blackScreen, 0.4f, 0.5f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(optionsTitle, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(music, 0.1f));
        musicSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(sfx, 0.1f));
        sfxSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsPause, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsPauseText, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(backPause, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(backPauseText, 0.1f));
        statsPause.gameObject.GetComponent<Button>().enabled = true;
        backPause.gameObject.GetComponent<Button>().enabled = true;
        musicSlider.gameObject.GetComponent<Slider>().enabled = true;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = true;
    }

    private void onStatsBackPausePress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onStatsBackPause());
    }

    public IEnumerator onStatsBackPause()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(FadeOutText(statsTitle, 0.01f));
        yield return StartCoroutine(FadeOutText(totalDeaths, 0.01f));
        yield return StartCoroutine(FadeOutText(totalDeathsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(totalPoints, 0.01f));
        yield return StartCoroutine(FadeOutText(totalPointsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(averagePoints, 0.01f));
        yield return StartCoroutine(FadeOutText(averagePointsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(highScore, 0.01f));
        yield return StartCoroutine(FadeOutText(highScoreValue, 0.01f));
        yield return StartCoroutine(FadeOutText(maxGhosts, 0.01f));
        yield return StartCoroutine(FadeOutText(maxGhostsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(totalGhosts, 0.01f));
        yield return StartCoroutine(FadeOutText(totalGhostsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(statsBackText, 0.01f));
        yield return StartCoroutine(FadeOutButton(statsBackPause, 0.01f));

        statsTitle.gameObject.SetActive(false);
        totalDeaths.gameObject.SetActive(false);
        totalDeathsValue.gameObject.SetActive(false);
        totalPoints.gameObject.SetActive(false);
        totalPointsValue.gameObject.SetActive(false);
        averagePoints.gameObject.SetActive(false);
        averagePointsValue.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        highScoreValue.gameObject.SetActive(false);
        maxGhosts.gameObject.SetActive(false);
        maxGhostsValue.gameObject.SetActive(false);
        totalGhosts.gameObject.SetActive(false);
        totalGhostsValue.gameObject.SetActive(false);
        statsBackPause.gameObject.SetActive(false);

        optionsTitle.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        statsPause.gameObject.SetActive(true);
        backPause.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(optionsTitle, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(music, 0.05f));
        musicSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsPause, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsPauseText, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(backPause, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(backPauseText, 0.05f));
        statsPause.gameObject.GetComponent<Button>().enabled = true;
        backPause.gameObject.GetComponent<Button>().enabled = true;
        musicSlider.gameObject.GetComponent<Slider>().enabled = true;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = true;
    }

    public IEnumerator onStatsPause()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        // unspawn options but keeps black background
        yield return StartCoroutine(FadeOutText(optionsTitle, 0.05f));
        yield return StartCoroutine(FadeOutText(music, 0.05f));
        musicSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutButton(statsPause, 0.05f));
        yield return StartCoroutine(FadeOutText(statsPauseText, 0.05f));
        yield return StartCoroutine(FadeOutButton(backPause, 0.05f));
        yield return StartCoroutine(FadeOutText(backPauseText, 0.05f));
        optionsTitle.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        statsPause.gameObject.SetActive(false);
        backPause.gameObject.SetActive(false);

        statsTitle.gameObject.SetActive(true);
        totalDeaths.gameObject.SetActive(true);
        totalDeathsValue.gameObject.SetActive(true);
        totalPoints.gameObject.SetActive(true);
        totalPointsValue.gameObject.SetActive(true);
        averagePoints.gameObject.SetActive(true);
        averagePointsValue.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
        highScoreValue.gameObject.SetActive(true);
        maxGhosts.gameObject.SetActive(true);
        maxGhostsValue.gameObject.SetActive(true);
        totalGhosts.gameObject.SetActive(true);
        totalGhostsValue.gameObject.SetActive(true);
        statsBackPause.gameObject.SetActive(true);

        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsTitle, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalDeaths, 0.05f));
        totalDeathsValue.text = PlayerPrefs.GetInt("totalDeaths").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalDeathsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalPoints, 0.05f));
        totalPointsValue.text = PlayerPrefs.GetInt("totalPoints").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalPointsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(averagePoints, 0.05f));
        if (PlayerPrefs.GetInt("totalDeaths") == 0)
        {
            PlayerPrefs.SetFloat("averagePoints", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("averagePoints", (1.0f * PlayerPrefs.GetInt("totalPoints")) / (1.0f * PlayerPrefs.GetInt("totalDeaths")));
        }


        averagePointsValue.text = PlayerPrefs.GetFloat("averagePoints").ToString("0.00");

        yield return StartCoroutine(ScoreBoard.instance.FadeInText(averagePointsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(highScore, 0.05f));
        highScoreValue.text = PlayerPrefs.GetInt("highscore").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(highScoreValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(maxGhosts, 0.05f));
        maxGhostsValue.text = PlayerPrefs.GetInt("maxGhosts").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(maxGhostsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalGhosts, 0.05f));
        totalGhostsValue.text = PlayerPrefs.GetInt("totalGhosts").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalGhostsValue, 0.05f));

        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsBackPauseText, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsBackPause, 0.05f));
        statsBackPause.gameObject.GetComponent<Button>().enabled = true;
    }

    public void onStatsPausePress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onStatsPause());
    }

    public IEnumerator unspawnOptions()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(FadeOutText(optionsTitle, 0.05f));
        yield return StartCoroutine(FadeOutText(music, 0.05f));
        musicSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutButton(statsButton, 0.05f));
        yield return StartCoroutine(FadeOutText(stats, 0.05f));
        yield return StartCoroutine(FadeOutButton(statsPause, 0.05f));
        yield return StartCoroutine(FadeOutText(statsPauseText, 0.05f));
        yield return StartCoroutine(FadeOutButton(backButton, 0.05f));
        yield return StartCoroutine(FadeOutText(back, 0.05f));
        yield return StartCoroutine(FadeOutButton(backPause, 0.05f));
        yield return StartCoroutine(FadeOutText(backPauseText, 0.05f));
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(blackScreen.GetComponent<SpriteRenderer>().color.r, blackScreen.GetComponent<SpriteRenderer>().color.g, blackScreen.GetComponent<SpriteRenderer>().color.b, 0);
        optionsTitle.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        statsButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        backPause.gameObject.SetActive(false);
        statsPause.gameObject.SetActive(false);
    }

    public IEnumerator unspawnOptionsPause()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(FadeOutText(optionsTitle, 0.05f));
        yield return StartCoroutine(FadeOutText(music, 0.05f));
        musicSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutButton(statsPause, 0.05f));
        yield return StartCoroutine(FadeOutButton(backPause, 0.05f));
        optionsTitle.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        statsPause.gameObject.SetActive(false);
        backPause.gameObject.SetActive(false);
    }

    public IEnumerator onStats()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        // unspawn options but keeps black background
        yield return StartCoroutine(FadeOutText(optionsTitle, 0.05f));
        yield return StartCoroutine(FadeOutText(music, 0.05f));
        musicSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(false);
        yield return StartCoroutine(FadeOutButton(statsButton, 0.05f));
        yield return StartCoroutine(FadeOutText(stats, 0.05f));
        yield return StartCoroutine(FadeOutButton(backButton, 0.05f));
        yield return StartCoroutine(FadeOutText(back, 0.05f));
        yield return StartCoroutine(FadeOutButton(backPause, 0.05f));
        yield return StartCoroutine(FadeOutText(backPauseText, 0.05f));
        optionsTitle.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        statsButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        backPause.gameObject.SetActive(false);

        statsTitle.gameObject.SetActive(true);
        totalDeaths.gameObject.SetActive(true);
        totalDeathsValue.gameObject.SetActive(true);
        totalPoints.gameObject.SetActive(true);
        totalPointsValue.gameObject.SetActive(true);
        averagePoints.gameObject.SetActive(true);
        averagePointsValue.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
        highScoreValue.gameObject.SetActive(true);
        maxGhosts.gameObject.SetActive(true);
        maxGhostsValue.gameObject.SetActive(true);
        totalGhosts.gameObject.SetActive(true);
        totalGhostsValue.gameObject.SetActive(true);
        statsBack.gameObject.SetActive(true);

        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsTitle, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalDeaths, 0.05f));
        totalDeathsValue.text = PlayerPrefs.GetInt("totalDeaths").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalDeathsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalPoints, 0.05f));
        totalPointsValue.text = PlayerPrefs.GetInt("totalPoints").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalPointsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(averagePoints, 0.05f));
        PlayerPrefs.GetFloat("averagePoints");
        if (PlayerPrefs.GetInt("totalDeaths") == 0)
        {
            PlayerPrefs.SetFloat("averagePoints", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("averagePoints", (1.0f * PlayerPrefs.GetInt("totalPoints")) / (1.0f * PlayerPrefs.GetInt("totalDeaths")));
        }

        averagePointsValue.text = PlayerPrefs.GetFloat("averagePoints").ToString("0.00");
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(averagePointsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(highScore, 0.05f));
        highScoreValue.text = PlayerPrefs.GetInt("highscore").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(highScoreValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(maxGhosts, 0.05f));
        maxGhostsValue.text = PlayerPrefs.GetInt("maxGhosts").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(maxGhostsValue, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalGhosts, 0.05f));
        totalGhostsValue.text = PlayerPrefs.GetInt("totalGhosts").ToString();
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(totalGhostsValue, 0.05f));

        yield return StartCoroutine(ScoreBoard.instance.FadeInText(statsBackText, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsBack, 0.05f));
        statsBack.gameObject.GetComponent<Button>().enabled = true;
    }

    public IEnumerator onStatsBack()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(FadeOutText(statsTitle, 0.01f));
        yield return StartCoroutine(FadeOutText(totalDeaths, 0.01f));
        yield return StartCoroutine(FadeOutText(totalDeathsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(totalPoints, 0.01f));
        yield return StartCoroutine(FadeOutText(totalPointsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(averagePoints, 0.01f));
        yield return StartCoroutine(FadeOutText(averagePointsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(highScore, 0.01f));
        yield return StartCoroutine(FadeOutText(highScoreValue, 0.01f));
        yield return StartCoroutine(FadeOutText(maxGhosts, 0.01f));
        yield return StartCoroutine(FadeOutText(maxGhostsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(totalGhosts, 0.01f));
        yield return StartCoroutine(FadeOutText(totalGhostsValue, 0.01f));
        yield return StartCoroutine(FadeOutText(statsBackText, 0.01f));
        yield return StartCoroutine(FadeOutButton(statsBack, 0.01f));

        statsTitle.gameObject.SetActive(false);
        totalDeaths.gameObject.SetActive(false);
        totalDeathsValue.gameObject.SetActive(false);
        totalPoints.gameObject.SetActive(false);
        totalPointsValue.gameObject.SetActive(false);
        averagePoints.gameObject.SetActive(false);
        averagePointsValue.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        highScoreValue.gameObject.SetActive(false);
        maxGhosts.gameObject.SetActive(false);
        maxGhostsValue.gameObject.SetActive(false);
        totalGhosts.gameObject.SetActive(false);
        totalGhostsValue.gameObject.SetActive(false);
        statsBack.gameObject.SetActive(false);

        optionsTitle.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        statsButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(optionsTitle, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(music, 0.05f));
        musicSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(sfx, 0.05f));
        sfxSlider.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(statsButton, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(stats, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(backButton, 0.05f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(back, 0.05f));
        statsButton.gameObject.GetComponent<Button>().enabled = true;
        backButton.gameObject.GetComponent<Button>().enabled = true;
        musicSlider.gameObject.GetComponent<Slider>().enabled = true;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = true;
    }

    public void onStatsBackPress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onStatsBack());
    }

    public void onStatsPress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onStats());
    }

    public IEnumerator onBackMenu()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        yield return StartCoroutine(unspawnOptions());
        title.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(title, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(play, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(playText, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInButton(options, 0.1f));
        yield return StartCoroutine(ScoreBoard.instance.FadeInText(optionsText, 0.1f));
        play.gameObject.GetComponent<Button>().enabled = true;
        options.gameObject.GetComponent<Button>().enabled = true;
    }

    public void onBackMenuPress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onBackMenu());
    }

    public void onOptionsMenuPress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onOptionsMenu());
    }

    public void onPlayPress()
    {
        SoundEffects.instance.playSound("click");
        StartCoroutine(onPlay());
    }

    public void onPlayImmediately()
    {
        play.gameObject.GetComponent<Button>().enabled = false;
        pause.gameObject.GetComponent<Button>().enabled = false;
        menu.gameObject.GetComponent<Button>().enabled = false;
        menuPause.gameObject.GetComponent<Button>().enabled = false;
        statsButton.gameObject.GetComponent<Button>().enabled = false;
        backButton.gameObject.GetComponent<Button>().enabled = false;
        statsBack.gameObject.GetComponent<Button>().enabled = false;
        backPause.gameObject.GetComponent<Button>().enabled = false;
        statsPause.gameObject.GetComponent<Button>().enabled = false;
        statsBackPause.gameObject.GetComponent<Button>().enabled = false;
        musicSlider.gameObject.GetComponent<Slider>().enabled = false;
        sfxSlider.gameObject.GetComponent<Slider>().enabled = false;

        Player.instance.StartCoroutine(Player.instance.SwitchDir());
        player.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
        title.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        point.SetActive(true);
        upArrow.SetActive(false);
        background.SetActive(false);
        pause.gameObject.GetComponent<Button>().enabled = true;
    }

    private void onMenuPausePress()
    {
        onMenuPress();
    }

    public void onMenuPress()
    {
        CarryOver.instance.restart = false;
        GameOver();
    }

    public IEnumerator FadeOutText(Text text, float time)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a >= 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (0.04f / time));
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }

    public IEnumerator FadeOutButton(Button button, float time)
    {
        button.GetComponent<Image>().color = new Color(255, 255, 255, button.GetComponent<Image>().color.a);
        while (button.GetComponent<Image>().color.a >= 0)
        {
            button.GetComponent<Image>().color = new Color(255, 255, 255, button.GetComponent<Image>().color.a - .04f / time);
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }

	private void Awake()
	{
        instance = this;
	}

    public void GameOver()
    {
        PlayerGhost.x = 0;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

}
