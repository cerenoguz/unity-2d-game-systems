using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public List<GameObject> kalpList;
    public int kalpCount;
    [SerializeField] GameObject dinazorPrefab;
    [SerializeField] Transform dtransform;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera camera;
    [SerializeField] GroundSpawner groundS;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    [SerializeField] Animator dinasourAnimator;
    [SerializeField] Animation jump;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] TMP_Text scoreText;
    public float distanceScore;
    public float highScore;
    public List<GameObject> cellsList;

    private void Awake()
    {
        Time.timeScale = 1;
        Instance = this;
        kalpCount = kalpList.Count;
        rb = GetComponent<Rigidbody2D>();
        dinasourAnimator = GetComponent<Animator>();
        dinazorPrefab.transform.position = dtransform.position;
        RepeatingBG.instance.dinazor = dinazorPrefab;
        startTime = Time.deltaTime;
        highScore = PlayerPrefs.GetFloat("highscore");
    }

    public float pastTime;
    public float startTime;
    public float velocity = 5;
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        distanceScore += velocity * 3  * Time.deltaTime;

        scoreText.text = distanceScore.ToString("0");
        pastTime += Time.deltaTime;

        if (pastTime - startTime > 20)
        {
            velocity += 0.1f * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
            if (dinasourAnimator != null)
                dinasourAnimator.SetBool("Jumping", true);
        }
        else
        {
            if (dinasourAnimator != null)
                dinasourAnimator.SetBool("Jumping", false);
        }

        if (Input.touchCount > 0 && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
            if (dinasourAnimator != null)
                dinasourAnimator.SetBool("Jumping", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            --kalpCount;
            kalpList[kalpCount].SetActive(false);
            if (kalpCount == 0)
            {
                gameOver.SetActive(true);
                restartButton.SetActive(true);
                mainMenuButton.SetActive(true);
                dinazorPrefab.GetComponent<SpriteRenderer>().enabled = false;

                if (distanceScore > highScore)
                {
                    HighScoreSettings.highScore = distanceScore;
                    PlayerPrefs.SetFloat("highscore", HighScoreSettings.highScore);
                }
                Time.timeScale = 0;

            }
        }
        if (other.gameObject.tag == "Fall")
        {
            kalpList[0].SetActive(false);
            kalpList[1].SetActive(false);
            kalpList[2].SetActive(false);
            gameOver.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            dinazorPrefab.GetComponent<SpriteRenderer>().enabled = false;
            if (distanceScore > highScore)
            {
                HighScoreSettings.highScore = distanceScore;
                PlayerPrefs.SetFloat("highscore", HighScoreSettings.highScore);
            }
            Time.timeScale = 0;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            if (dinasourAnimator != null)
                dinasourAnimator.SetBool("Walking", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (dinasourAnimator != null)
                dinasourAnimator.SetBool("Walking", false);
        }
    }

}