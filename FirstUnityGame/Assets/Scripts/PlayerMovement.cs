using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float movementVelocity;

    public Vector3 v;


    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, movementForce * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(movementVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            //rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, -movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3(-movementVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            //rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        

        /*if (rb.position.y < -1f)
        {
            FindObjectOfType<GameMananger>().EndGame();
        }*/
    }

    public void movePlayerWithGround(Vector3 step)
    {
        rb.position += step;
        Debug.Log(step);
    }
}
