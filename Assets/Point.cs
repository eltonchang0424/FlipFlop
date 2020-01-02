using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    public GameObject pointParticle;
    public GameObject graphic;

	void Start () {
        graphic.GetComponent<SpriteRenderer>().color = new Color(graphic.GetComponent<SpriteRenderer>().color.r, graphic.GetComponent<SpriteRenderer>().color.g, graphic.GetComponent<SpriteRenderer>().color.b, 0);
        float randomX = Random.value * 8.5f - 4.25f;
        float randomY = Random.value * 7.5f - 3.75f;
        while((new Vector3(randomX, randomY, 0) - Player.instance.transform.position).magnitude < 3.5)
        {
            randomX = Random.value * 8.5f - 4.25f;
            randomY = Random.value * 7.5f - 3.75f;
        }
        transform.position = new Vector2(randomX, randomY);
        ScoreBoard.instance.StartCoroutine(ScoreBoard.instance.FadeInObject(graphic, 1, 0.5f));
	}
	
	void Update () {
		
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundEffects.instance.playSound("heal");
            PlayerPrefs.GetInt("totalPoints");
            PlayerPrefs.SetInt("totalPoints", PlayerPrefs.GetInt("totalPoints") + 1);
            Destroy(Instantiate(pointParticle, transform.position, Quaternion.identity), 0.25f);
            ScoreBoard.instance.IncrementScore();
            GameObject newPoint = Instantiate(gameObject);
            Destroy(gameObject);
        }
    }
}
