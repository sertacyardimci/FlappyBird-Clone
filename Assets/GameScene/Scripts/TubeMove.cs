using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMove : MonoBehaviour
{

    private float speed = 4;
    private GameValues gameValues;
    private ObjectPool objectPool;
    private ScoreTextController scoreTextController;
    private GameObject bird;

    public bool isIncreaseScore = false;

    void Awake()
    {

        gameValues = GameObject.Find("GameValues").GetComponent<GameValues>();
        objectPool = gameValues.ObjectPool;
        bird = GameObject.Find("Bird");
        if (this.gameObject.name != "Tube")
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        scoreTextController = GameObject.Find("ScoreText").GetComponent<ScoreTextController>();
    }

    void Update()
    {

        HideOrMove();
        ScoreIncrease();
    }
    private void HideOrMove()
    {

        if (this.transform.position.x < -50.5f && this.gameObject.activeSelf)
        {
            //buraya objectpool'a objeyi gönderme eklenecek.
            objectPool.AddTube(this.gameObject);
            this.gameObject.SetActive(false);


        }
        else
        {
            MoveWall();
        }


    }

    private void MoveWall()
    {
        if (this.gameObject.name != "Tube")
        {
            this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
        }

    }
    
    private void ScoreIncrease()
    {
        if (!isIncreaseScore && this.gameObject.transform.position.x < bird.transform.position.x)
        {
            gameValues.IncreaseScore();
            isIncreaseScore = true;
            scoreTextController.IncreaseScore();
        }


    }

}
