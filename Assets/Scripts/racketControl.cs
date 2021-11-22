using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketControl : MonoBehaviour
{
    Rigidbody rig;
    float mouseX, mouseY;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
        mouseX = Mathf.Clamp(mouseX, -0.3f, 0);
        mouseY = Mathf.Clamp(mouseY, -0.135f, 0.135f);

        transform.position = new Vector3(mouseX, mouseY, transform.position.z);
    }
}
