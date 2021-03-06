﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Public Variables - Public allows you to make changes to this variable in the Unity Editor.
    public float speed;
    public Text countText;
    public Text winText;

    //Private Variables - Privates ensures you cannot edit it in the Unity Editor.
    private Rigidbody rb; // Accessing the Rigidbody FUnction in the Unity Inspector Dashboard of the object.
    private int count;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    //Called just before nay physics calculations this is where physics will go
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 holds 3x/three decimal values in one container Vector3 (x, y, z)
        Vector3 movement = new Vector3(moveHorizontal,0, moveVertical); // x = Horizontal, y = top/up, z = Vertical
        rb.AddForce (movement * speed);
    }

    /** Destroy - It destroys the game object from the scene, thus causing it lose its value.
        Destroy(other.gameObject);**/
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            // Disables the Game Object, allowing it to retain its value.
            other.gameObject.SetActive(false);

            // Counting UI 
            count = count + 1; // also written as: count = count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
