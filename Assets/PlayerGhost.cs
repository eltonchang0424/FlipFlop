using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGhost : MonoBehaviour {

    SpriteRenderer sr;
    public static int x = 1;
    public float delay = 0.5f;
    bool invulnerable = true;
    public GameObject wallHitParticlePrefab;
    bool running = false;
    public GameObject deathParticle;

	void Start () {
        SoundEffects.instance.playSound("shadow");
        Player.instance.maxGhosts += 1;
        PlayerPrefs.GetInt("totalGhosts");
        PlayerPrefs.SetInt("totalGhosts", PlayerPrefs.GetInt("totalGhosts") + 1);
        if(Player.instance.maxGhosts > PlayerPrefs.GetInt("maxGhosts"))
        {
            PlayerPrefs.SetInt("maxGhosts", Player.instance.maxGhosts);
        }
        transform.position = Player.instance.transform.position;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Player.instance.GetComponent<SpriteRenderer>().sprite;
        SpriteRenderer PlayerSpriteRenderer = Player.instance.GetComponent<SpriteRenderer>();
        sr.color = new Color(1.0f - PlayerSpriteRenderer.color.r, 1.0f - PlayerSpriteRenderer.color.g, 1.0f - PlayerSpriteRenderer.color.b);
        StartCoroutine(StartInvulnerability(invulnerable));
	}
	
	void Update () {
        Vector2 playerPos = Player.instance.transform.position;
        StartCoroutine(MoveDelay(playerPos));
	}

    IEnumerator MoveDelay(Vector2 playerPos)
    {
        running = true;
        yield return new WaitForSeconds(delay);
        transform.position = playerPos;
        running = false;
    }

    IEnumerator StartInvulnerability(bool invulernable)
    {
        StartCoroutine(Shake(delay, 0.075f));
        float time = 0;
        Color alpha = sr.color;
        alpha.a = 0;
        sr.color = alpha;
        while(time < delay)
        {
            alpha.a += Time.fixedDeltaTime / delay;
            sr.color = alpha;
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;

    }

    IEnumerator Shake(float time, float magnitude)
    {
        Vector2 originalPos = Camera.main.transform.position;
        float t = 0;
        while (t < time)
        {
            float randomX = Random.Range(-1, 1) * magnitude;
            float randomY = Random.Range(-1, 1) * magnitude;

            Camera.main.transform.localPosition = new Vector2(randomX, randomY);
            t += Time.fixedDeltaTime;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Camera.main.transform.localPosition = originalPos;
    }

    IEnumerator Shaker()
    {
        ScoreBoard.instance.disablePause();
        Time.timeScale = 0;
        yield return StartCoroutine(Shake(0.5f, 0.5f));
        ScoreBoard.instance.FadeInGameOver();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Player"))
        {
            if (!invulnerable)
            {
                SoundEffects.instance.playSound("death");
                PlayerPrefs.GetInt("totalDeaths");
                PlayerPrefs.SetInt("totalDeaths", PlayerPrefs.GetInt("totalDeaths") + 1);
                StartCoroutine(Shaker());
            }

        }

	}
}
