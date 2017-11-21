using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    private GameObject tube, clonedTube;
    private GameValues gameValues;
    private ObjectPool objectPool;
    private TubeMove tubeMove;
    private float time = 0;

    private void Awake()
    {
        tube = GameObject.Find("Tube");
        gameValues = GameObject.Find("GameValues").GetComponent<GameValues>();
        objectPool = gameValues.ObjectPool;
        objectPool.SetTube(this.tube);
        objectPool.CreateObjects();
    }

    void Update()
    {
        time += Time.fixedDeltaTime;
        if (time > 1.5f)
        {

            time = 0;
            //buraya objectpool dan gameobject çekilecek.
            clonedTube = objectPool.GetFreeTube();
            clonedTube.gameObject.SetActive(true);
            clonedTube.GetComponent<TubeMove>().isIncreaseScore = false;
            tubeMove = clonedTube.GetComponent<TubeMove>();
            clonedTube.transform.position = tube.transform.position;
            clonedTube.transform.Translate(0, Random.Range(-1.5f, 1.5f), 0);


        }
    }

}
