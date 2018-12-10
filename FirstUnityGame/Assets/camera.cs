using UnityEngine;

public class camera : MonoBehaviour {

    public Transform playerPos;

    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + playerPos.position;
    }
}
