using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject coinCollected;

    public float speed;

    private int coinCount;

    private int totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        coinCollected.GetComponent<Text>().text = "Coin collected: " + 0;

        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * -speed);
        }

        if (coinCount == totalCoin)
        {
            print("You win!");
            SceneManager.LoadScene("WinScene");
        }

        if (transform.position.y < -5)
        {
            print("YOU LOSE!");
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinCount++;

            coinCollected.GetComponent<Text>().text = "Coin collected: " + coinCount;
            Destroy(other.gameObject);
        }
    }
}
