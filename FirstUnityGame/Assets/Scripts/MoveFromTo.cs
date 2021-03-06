﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFromTo : MonoBehaviour {

    public Vector3 distanceToMove;
    public Vector3 to;

    Vector3 from, step, currPos;

    public float speed = 5f;


    float EP = 0.1f;
    bool isThereRes = false;

    void Start()
    {
        currPos = transform.position;
        from = transform.position;
        to = from + distanceToMove;


    }

    void FixedUpdate()
    {
        isThere();
        if (!isThereRes)
        {
            measureStep();
            currPos += step;
            transform.position = currPos;
        }
        else
        {
            Vector3 tmp = from;
            from = to;
            to = tmp;
        }

        
    }

    void measureStep()
    {
        step = new Vector3(0, 0, 0);
        if(Mathf.Abs(currPos.x - to.x) > EP)
            step.x = ((from.x < to.x)? 1 : -1) * speed * Time.deltaTime;

        if(Mathf.Abs(currPos.y - to.y) > EP)
            step.y = ((from.y < to.y) ? 1 : -1) * speed * Time.deltaTime;

        if(Mathf.Abs(currPos.z - to.z) > EP)
            step.z = ((from.z < to.z) ? 1 : -1) * speed * Time.deltaTime;
    }

    void isThere()
    {
        if(
            Mathf.Abs(currPos.x - to.x) < EP &&
            Mathf.Abs(currPos.y - to.y) < EP &&
            Mathf.Abs(currPos.z - to.z) < EP
           )
        {
            isThereRes = true;
        }
        else
        {
            isThereRes = false;
        }

    }

    public void playerOnGround(/*GameObject movingGround*/)
    {
        //Debug.Log("movingGround = " + movingGround.name + " this = " + gameObject.name);
        //if(movingGround.name == gameObject.name)
            FindObjectOfType<PlayerMovement>().movePlayerWithGround(step);
    }
}

