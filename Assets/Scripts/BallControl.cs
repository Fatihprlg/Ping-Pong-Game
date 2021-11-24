using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    Rigidbody rig;
    public GameObject ballPos;
    public Image bgImage;
    public Text gameOverTxt, scoreText;
    public static bool gameOver = false;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        rig.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            gameOver = true;
            GameOver();
        }
    }
    void GameOver()
    {
        bgImage.color = Color32.Lerp(bgImage.color, new Color32(79, 79, 79, 255), 0.3f);
        string sc = scoreText.text;
        int hiScore = PlayerPrefs.GetInt("hiScore");
        Debug.Log("hiscore: " + hiScore);
        scoreText.enabled = false;
        if (int.Parse(sc) > hiScore)
        {
            hiScore = int.Parse(sc);
        }
        gameOverTxt.enabled = true;
        gameOverTxt.text = "Game Over\nScore: " + sc + "\nHi-Score: " + hiScore.ToString();
        PlayerPrefs.SetInt("hiScore", hiScore);
        transform.position = ballPos.transform.position;
        rig.useGravity = false;
        rig.velocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
    }
}
