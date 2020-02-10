using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical"));
        
        if(input.sqrMagnitude > 0.1f)
        {
            transform.Rotate(Vector3.up, input.x);
            transform.GetChild(0).Rotate(Vector3.right, input.y);
        }

        transform.position = player.position;
    }
}
