using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public float jumpForce = 100f;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Transform cam;
    public float camMoveSpeed = 0.125f;
    public Transform playerPosition;
    public Color[] colors;
    public string[] colorTags = { "yellowSegment", "violetSegment", "pinkSegment", "cyanSegment" };

    private string colorTag;

    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        getRandomColor();
        // spriteRenderer.color = Color.blue;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (rb.position.y < -6)
        {
            // Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != colorTag && col.tag != "checkPoint")
        {
            Debug.Log("Lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (col.tag == "checkPoint")
        {
            getRandomColor();
            Vector3 targetPosition = new Vector3(0, playerPosition.position.y + 3, -10);

            cam.position = targetPosition;


            Destroy(col.gameObject);
            score++;
            scoreText.text = score.ToString();
        }

    }


    void getRandomColor()
    {
        int idx = Random.Range(0, 4);
        spriteRenderer.color = colors[idx];
        colorTag = colorTags[idx];
    }
}
