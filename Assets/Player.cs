using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public static Player instance;
    public GameObject wallHitParticlePrefab;
    public int jumpX = 13;
    public int jumpY = 16;
    public GameObject upArrow;
    public GameObject downArrow;
    public Rigidbody2D rb;
    Color downColor;
    Color upColor;
    public GameObject pauseButton;
    Rect pauseRect;
    public Vector2 playerVelPause;
    public GameObject gameBackground;
    public int maxGhosts = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        downColor = cam.backgroundColor;
        upColor = new Color(45/255f, 200/255f, 255/255f);
        rb = GetComponent<Rigidbody2D>();

        RectTransform rt = pauseButton.GetComponent<RectTransform>();
        pauseRect = new Rect(rt.transform.position - new Vector3(1.5f, 1.5f), new Vector2(1.5f, 1.5f));
    }

	void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, .5f, 1 << 8);
        if(hit)
        {
            Destroy(Instantiate(wallHitParticlePrefab, hit.point, Quaternion.identity), 0.5f);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.right, .5f, 1 << 8);
        if (hit)
        {
            Destroy(Instantiate(wallHitParticlePrefab, hit.point, Quaternion.identity), 0.5f);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.up, .5f, 1 << 8);
        if (hit)
        {
            Destroy(Instantiate(wallHitParticlePrefab, hit.point, Quaternion.identity), 0.5f);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.down, .5f, 1 << 8);
        if (hit)
        {
            Destroy(Instantiate(wallHitParticlePrefab, hit.point, Quaternion.identity), 0.5f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(pauseRect.Contains(mousePos))
            {
                return;
            }

            if(rb.gravityScale != 0.0f && Time.timeScale != 0)
            {
                SoundEffects.instance.playSound("jump");
            }

            if(rb.gravityScale > 0)
            {
                if (rb.velocity.x > 0)
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(jumpX, jumpY), ForceMode2D.Impulse);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(-jumpX, jumpY), ForceMode2D.Impulse);
                }
            }

            else
            {
                if (rb.velocity.x > 0)
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(jumpX, -jumpY), ForceMode2D.Impulse);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(-jumpX, -jumpY), ForceMode2D.Impulse);
                }
            }
        }
    }

    public IEnumerator SwitchDir()
    {
        yield return new WaitForSeconds(5);

        // warning flash
        float flashDur = 0.75f;
        int flashCount = 5;
        //Color currentColor = cam.backgroundColor;
        //Color colorToFlash;

        Color currentTextColor = ScoreBoard.instance.scoreText.color;
        Color downScore = new Color(255/255f, 189/255f, 189/255f);
        Color textColorToFlash;
        Color upScore = new Color(156/255f, 240/255f, 255/255f);

        /*if (currentColor.Equals(downColor))
        {
            colorToFlash = upColor;
            textColorToFlash = upScore;
        }
        else
        {
            colorToFlash = downColor;
            textColorToFlash = downScore;
        }
        for (int x = 0; x < flashCount; x++)
        {
            cam.backgroundColor = colorToFlash;
            ScoreBoard.instance.scoreText.color = textColorToFlash;
            yield return new WaitForSeconds(flashDur / flashCount / 2);
            cam.backgroundColor = currentColor;
            ScoreBoard.instance.scoreText.color = currentTextColor;
            yield return new WaitForSeconds(flashDur / flashCount / 2);
        }
        */
        if (currentTextColor.Equals(downScore))
        {
            textColorToFlash = upScore;
        }
        else
        {
            textColorToFlash = downScore;
        }

        for (int x = 0; x < flashCount; x++)
        {
            ScoreBoard.instance.scoreText.color = textColorToFlash;
            yield return new WaitForSeconds(flashDur / flashCount / 2);
            ScoreBoard.instance.scoreText.color = currentTextColor;
            yield return new WaitForSeconds(flashDur / flashCount / 2);
        }

        // change gravity smoothly
        float targetGravity = rb.gravityScale * -1;

        SoundEffects.instance.playSound("gravity");

        while(Mathf.Abs(rb.gravityScale - targetGravity) < 0.05)
        {
            rb.gravityScale += targetGravity * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.gravityScale = targetGravity;

        // change color based on gravity
        if (rb.gravityScale > 0)
        {
            upArrow.SetActive(false);
            //cam.backgroundColor = downColor;
            ScoreBoard.instance.scoreText.color = downScore;
            downArrow.SetActive(true);
            gameBackground.GetComponent<Animator>().SetTrigger("changeToRed");
        }

        else
        {
            downArrow.SetActive(false);
            //cam.backgroundColor = upColor;
            ScoreBoard.instance.scoreText.color = upScore;
            upArrow.SetActive(true);
            gameBackground.GetComponent<Animator>().SetTrigger("changeToBlue");
        }

            StartCoroutine(SwitchDir());
    }

     

}