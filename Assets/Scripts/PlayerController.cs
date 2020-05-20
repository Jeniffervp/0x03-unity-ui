using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 500f;
    public Rigidbody rigb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;

    public void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
            score = 0;
            health = 5;
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rigb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            rigb.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            rigb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            rigb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
