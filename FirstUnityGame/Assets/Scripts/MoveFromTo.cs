using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFromTo : MonoBehaviour {

    public Vector3 to;
    Vector3 from, step, currPos;
    public float speed = 1f;

    float EP = 0.1f;
    bool isThereRes = false;

    void Start()
    {
        currPos = transform.position;
        from = transform.position;


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

    public void playerOnGround()
    {
        FindObjectOfType<PlayerMovement>().movePlayerWithGround(step);
    }
}

