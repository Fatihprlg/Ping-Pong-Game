using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class racketControl : MonoBehaviour
{
    Rigidbody rig;
    float mouseX, mouseY;
    int score = 0;
    public Text scoreText, startText, gameOverTxt;
    public GameObject ball;
    public Image bgImage;
    float bounceForce = 0.6f;
    bool gameStart = false;
    AudioSource ballSound;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ballSound = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(Physics.gravity.x, -2, Physics.gravity.z);

    }
    private void Update()
    {
        if (BallControl.gameOver)
        {
            gameStart = false;
            ResetGame();
        }
            
        if (Input.GetMouseButtonDown(0) && !gameStart)
        {
            gameStart = true;
            BallControl.gameOver = false;
            GameStart();
        }
    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
            mouseX += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 3;
            mouseY += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * 3;
            mouseY = Mathf.Clamp(mouseY, -0.3f, 0);
            mouseX = Mathf.Clamp(mouseX, -0.135f, 0.135f);
            //Debug.Log(Physics.gravity);
            scoreText.text = score.ToString();

            transform.position = new Vector3(mouseX, mouseY, transform.position.z);
            transform.rotation = Quaternion.Euler(mouseX * 50, -90, transform.rotation.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("degdi");
        ballSound.Play();
        score++;
        Vector3 normal = collision.contacts[0].normal;
        Rigidbody colRig = collision.collider.GetComponent<Rigidbody>();
        if (colRig != null)
        {
            Vector3 vel = colRig.velocity;
            Debug.Log("vel: " + vel);
            Debug.Log("reflect: " + Vector3.Reflect(vel, normal));
            // Debug.Log(rig.velocity);
            vel.y += 0.1f;
            if (vel.y >= -0.5f)
                vel.y -= bounceForce;
            Debug.Log("vel2: " + vel);
            colRig.velocity = Vector3.Reflect(vel, normal);
        }
    }
    void GameStart()
    {
        ball.GetComponent<Rigidbody>().useGravity = true;
        startText.enabled = false;
        scoreText.enabled = true;
        gameOverTxt.enabled = false;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }
    void ResetGame()
    {
        transform.position = new Vector3(0, -0.069f, -12.699f);
        transform.rotation = Quaternion.Euler(0, -90, 90);
        startText.enabled = true;
        bgImage.color = new Color32(255, 255, 255, 255);
        score = 0;
    }
}
