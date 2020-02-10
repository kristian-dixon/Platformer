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
        Vector3 velocityGravityless = mRB.velocity;
        float gravity = mRB.velocity.y;
        velocityGravityless.y = 0;

        if(input.sqrMagnitude > 0.1f)
        {
            //Orient so facing input dir
            var inputCamSpace = mCamera.TransformVector(new Vector3(input.x, 0, input.y));
            inputCamSpace.y = 0;

            var lookDir = Vector3.RotateTowards(transform.forward, inputCamSpace, 20 * Time.deltaTime, 0);
            
            transform.LookAt(lookDir + transform.position);

            velocityGravityless = Vector3.ClampMagnitude(velocityGravityless + inputCamSpace, 10);
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (Mathf.Abs(gravity) < 0.01f)
            {
                gravity = 10;
            }
        }

        mRB.velocity = velocityGravityless + Vector3.up * gravity;
    }
}
