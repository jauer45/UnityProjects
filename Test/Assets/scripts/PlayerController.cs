using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    public AudioClip pickupSound;
    private AudioSource source;
    private float volLowRandse = 0.5f;
    private float volHighRandse = 1.0f;

    //Set onLoad
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Init PlayerController 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    // Physics Logic and Event Stuff set/called here
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            float vol = Random.Range(volLowRandse, volHighRandse);
            other.gameObject.SetActive(false);
            source.PlayOneShot(pickupSound, vol);
            count = count + 1;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if( count >= 9 )
        {
            winText.text = "You Win !!!";
        }
    }


}
