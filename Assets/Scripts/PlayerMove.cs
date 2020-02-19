using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMove : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    public float speedMod = 1;

    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    { 
        float mSpeedHori = Input.GetAxis("Horizontal");
        float mSpeedVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(mSpeedHori * speedMod, 0, mSpeedVert * speedMod);

        rb.AddForce(movement);

        if (Input.GetButtonDown("Cancel"))// detects when the player presses esc
        {
            Application.Quit();// quits game
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "YOU WIN!";
        }
    }
    
}
