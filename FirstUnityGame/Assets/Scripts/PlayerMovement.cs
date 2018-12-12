using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float movementVelocity = 500;
    public float brakesControl = 100;

    public float downForce = -10;

    public float MAX_Y_POS = 5;
    public float MIN_Y_POS = -1;

    float EP = 0.1f;

    public int direction = 0;

    public Vector3 v;


    void FixedUpdate()
    {
        rb.AddForce(0, downForce, 0);
        //rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if (Input.GetKey("w"))
        {
            direction = 0;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, movementForce * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (Input.GetKey("d"))
        {
            direction = 1;
            rb.velocity = new Vector3(movementVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            //rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            direction = 2;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, -movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            direction = 3;
            rb.velocity = new Vector3(-movementVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            //rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {
            float x = rb.velocity.x;
            float y = rb.velocity.y;
            float z = rb.velocity.z;


            measureVelocityAfterBrakes(ref x);
            //measureVelocityAfterBrakes(ref y);
            measureVelocityAfterBrakes(ref z);
            rb.velocity = new Vector3(x , y, z);

            //rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y > MAX_Y_POS)
        {
            rb.position = new Vector3(rb.position.x, MAX_Y_POS, rb.position.z);
        }
        if (rb.position.y < MIN_Y_POS)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        transform.rotation = Quaternion.Euler(270, 0, 90 * direction);

            /*if (rb.position.y < -1f)
            {
                FindObjectOfType<GameMananger>().EndGame();
            }*/
    }

    public void movePlayerWithGround(Vector3 step)
    {
        rb.position += step;
    }

    void measureVelocityAfterBrakes(ref float x)
    {
        if (Mathf.Abs(x) > EP)
            x += ((x > 0) ? -1 : 1) * Time.deltaTime * brakesControl;
        else
            x = 0;
    }
}
