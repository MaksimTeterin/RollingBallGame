using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public Text winText;
    public GameObject Wall;
    private Rigidbody rb;
    public int Score;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText();
        winText.text = "";
        ScoreText.text = "Score: " + Score.ToString();
        speed = 10;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //Restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);

            Score = Score + 1;
            SetScoreText();
            if (Score >= 5)
            {
                Wall.gameObject.SetActive(false);
            }

        }

        if (other.gameObject.tag == "danger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();

        if (Score >= 5)
        {
            winText.text = "You Win! Press R to restart or ESC to exit";
        }
    }
}
