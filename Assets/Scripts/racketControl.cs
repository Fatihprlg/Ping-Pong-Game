using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketControl : MonoBehaviour
{
    Rigidbody rig;
    float mouseX, mouseY;
    float bounceForce = 1;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(Physics.gravity.x, -1, Physics.gravity.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);*/
        
    }
    private void FixedUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 3;
        mouseY += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * 3;
        mouseY = Mathf.Clamp(mouseY, -0.3f, 0);
        mouseX = Mathf.Clamp(mouseX, -0.135f, 0.135f);
        //Debug.Log(Physics.gravity);

        transform.position = new Vector3(mouseX, mouseY, transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("degdi");
        Rigidbody colRig = collision.collider.GetComponent<Rigidbody>();
        if (colRig != null)
        {
            Vector3 vel = colRig.velocity;
            vel.y = bounceForce;
            colRig.velocity = vel;
        }
    }
}
