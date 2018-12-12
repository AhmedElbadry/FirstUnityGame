using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float movementVelocity = 500;
    public float brakesControl = 100;

    public float downForce = -10;

    public float MAX_Y_POS = 5;
    public float MIN_Y_POS = -1;

    float EP = 0.1f;

    public int new_direction, direction = 1;
    public int [] angle = { -1, 0, 90, 45, 180, -1, 135, -1, 270, 315, -1, -1, 225, -1, -1, -1};

    public Vector3 v;


    void FixedUpdate()
    {
        new_direction = 0;
        rb.AddForce(0, downForce, 0);
        //rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if (Input.GetKey("w"))
        {
            new_direction |= (1 << 0);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, movementForce * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (Input.GetKey("d"))
        {
            new_direction |= (1 << 1);
            rb.velocity = new Vector3(movementVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            //rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            new_direction |= (1 << 2);
            new_direction &= (~(1 << 0));
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -movementVelocity * Time.deltaTime);
            //rb.AddForce(0, 0, -movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            new_direction |= (1 << 3);
            new_direction &= (~(1 << 1));
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

        if (new_direction > 0)
            direction = new_direction;

        transform.rotation = Quaternion.Euler(270, 0, angle[direction]);

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
