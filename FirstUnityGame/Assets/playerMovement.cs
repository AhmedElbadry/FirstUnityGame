using UnityEngine;

public class playerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float movementForce;

    public Vector3 v;


    void FixedUpdate()
    {
        rb.velocity = v;
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, movementForce * Time.deltaTime, ForceMode.VelocityChange);
            
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        

        /*if (rb.position.y < -1f)
        {
            FindObjectOfType<GameMananger>().EndGame();
        }*/
    }
}
