using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement playerMovement;

    bool isPlayerOnMovingGround = false;

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "obstacle")
        {
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "movingGround")
        {
            isPlayerOnMovingGround = true;
        }
    }


    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "movingGround")
        {
            isPlayerOnMovingGround = false;
        }
    }

    void FixedUpdate()
    {
        if (isPlayerOnMovingGround)
        {
            FindObjectOfType<MoveFromTo>().playerOnGround();
        }
    }
}
