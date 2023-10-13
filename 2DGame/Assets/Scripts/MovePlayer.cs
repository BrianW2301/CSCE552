using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 15.0f;
    public float jumpForce = 500.0f;
    Vector2 moveVector = Vector2.zero;
    public bool isTouchingGround = false;
    public bool isTouchingSpike = false;
    public bool isTouchingFlag = false;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject backGroundMusic;
    [SerializeField] GameObject loseSound;
    public AudioSource jumpSound;
    public AudioSource winSound;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            jumpSound.Play();
            rb.AddForce(jumpForce * Vector2.up);
        }
        
        // Allows for variation in jumps based on how long jump is held
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (isTouchingSpike)
        {
            Time.timeScale = 0f;
            loseScreen.SetActive(true);
            backGroundMusic.SetActive(false);
        }
        if (isTouchingFlag)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);
            backGroundMusic.SetActive(false);
        }
    }
    
    private void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector = moveVector * moveSpeed;
        moveVector.y = rb.velocity.y;
        rb.velocity = moveVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = true;
        }
        if (collision.gameObject.tag == "Spike")
        {
            isTouchingSpike = true;
            loseSound.SetActive(true);
        }
        if (collision.gameObject.tag == "Flag")
        {
            winSound.Play();
            isTouchingFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = false;
        }
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
        isTouchingSpike = false;
        isTouchingFlag = false;
        Time.timeScale = 1f;
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
  }

    public void Menu()
    {
        isTouchingSpike = false;
        isTouchingFlag = false;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
}
