using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player;
    bool allowReturnToPlayerFwd = false;

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

            allowReturnToPlayerFwd = false;

            if (IsInvoking("UnlockCamera"))
                CancelInvoke("UnlockCamera");
        }
        else if(!allowReturnToPlayerFwd)
        {
            if(!IsInvoking("UnlockCamera"))
                Invoke("UnlockCamera", 3);
        }
        else if(allowReturnToPlayerFwd)
        {
            var speedMultiplier = 1.0f - ((Vector3.Dot(transform.forward, player.forward) * 0.5f) + 0.5f);

            var lookAt = Vector3.RotateTowards(transform.forward, player.forward, 10.0f * speedMultiplier * Time.deltaTime, 0);
            transform.LookAt(lookAt + transform.position);
        }

        transform.position = player.position;
    }

    void UnlockCamera()
    {
        allowReturnToPlayerFwd = true;
    }
}
