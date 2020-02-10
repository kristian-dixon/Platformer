using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Transform mCamera;
    Rigidbody mRB;
    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(input.sqrMagnitude > 0.1f)
        {
            //Orient so facing input dir
            var inputCamSpace = mCamera.TransformVector(new Vector3(input.x, 0, input.y));
            inputCamSpace.y = 0;

            var lookDir = Vector3.RotateTowards(transform.forward, inputCamSpace, 20 * Time.deltaTime, 0);
            
            transform.LookAt(lookDir + transform.position);

            mRB.velocity = Vector3.ClampMagnitude(mRB.velocity + inputCamSpace, 10);
        }
    }
}
