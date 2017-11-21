using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{

    Queue<GameObject> tubeQueue;
    Queue<GameObject> groundQueue;
    GameObject tube, ground, clonedTube, clonedGround;
    int tubeCount, groundCount;

    public ObjectPool(int tubeCount, int groundCount)
    {
        this.tubeCount = tubeCount;
        this.groundCount = groundCount;
        tubeQueue = new Queue<GameObject>(tubeCount);
        groundQueue = new Queue<GameObject>(groundCount);
    }

  
    public void CreateObjects()
    {
        for (int i = 0; i < this.tubeCount; i++)
        {
            clonedTube = Object.Instantiate(tube);
            tubeQueue.Enqueue(clonedTube);
        }
        for (int i = 0; i < this.groundCount; i++)
        {
            // clonedGround = Object.Instantiate(ground);
            // groundQueue.Enqueue(clonedGround);
        }
    }
    public void SetTube(GameObject tube)
    {
        this.tube = tube;
    }
    public void SetGround(GameObject ground)
    {
        this.ground = ground;
    }
    public GameObject GetFreeTube()
    {
       
        if (tubeQueue.Count <= 0)
        {
            NewTube();
        }
        return tubeQueue.Dequeue();
    }
    public GameObject GetFreeGround()
    {
        if (groundQueue.Count <= 0)
        {
            NewGround();
        }
        return groundQueue.Dequeue();
    }

    public void AddTube(GameObject tube)
    {
        tubeQueue.Enqueue(tube);
    }
    public void AddGround(GameObject ground)
    {
        groundQueue.Enqueue(ground);
    }

    private void NewTube()
    {
        clonedTube = GameObject.Instantiate(tube);
        tubeQueue.Enqueue(clonedTube);

    }
    private void NewGround()
    {
        clonedGround = GameObject.Instantiate(ground);
        groundQueue.Enqueue(clonedGround);

    }
}
