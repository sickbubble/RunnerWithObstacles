using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{

    public int score;
    public int maxScore;
    public TextMeshProUGUI CointText;
    public PlayerController PlayerController;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Collect");
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z);
            EndPanel.SetActive(true);
            if (score >= maxScore)
            {
                Debug.Log("Winnnneeeer");
                PlayerAnim.SetBool("Win", true);
            }
            else
            {
                Debug.Log("Lost brooo sorry");
                PlayerAnim.SetBool("Loose", true);
            }

            // Debug.Log("game oveeeer");
            PlayerController.runningSpeed = 0;
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Touched obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // TODO: move to game manager.
        }
    }


    public void AddCoin()
    {
        score++;
        CointText.text = "Score: " + score.ToString();

    }
}
