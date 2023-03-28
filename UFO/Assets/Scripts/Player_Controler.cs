using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controler : MonoBehaviour
{
    Rigidbody2D rd2D;
    public float speed;
    int Score;
    public Text scoreText;
    public Text winText;
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
        Score = 0;
        winText.enabled = false;
    }

    void Update()
    {
        if (Score == 7)
        {
            UpdateWin();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rd2D.AddForce(movement*speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            Score++;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {Score.ToString()}";

    }

    void UpdateWin()
    {
        winText.enabled = true;
        scoreText.enabled = false;
    }
}
