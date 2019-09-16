using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    public AudioClip coinSound;
    AudioSource audioSource;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            audioSource.PlayOneShot(coinSound, 0.5f);
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
            winText.text = "You Win!";
    }
}

