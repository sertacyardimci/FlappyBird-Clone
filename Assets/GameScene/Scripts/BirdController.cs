using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{


    private float characterBounceSpeed = 6;
    private GameValues gameValues;
    private GameObject character;
    private Rigidbody2D rb;

    void Start()
    {
        character = GameObject.Find("Bird");
        rb = character.GetComponent<Rigidbody2D>();
        gameValues = GameObject.Find("GameValues").GetComponent<GameValues>();
    }


    void Update()
    {

        BounceCharacter();
    }


    public void BounceCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * characterBounceSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
    }
}
