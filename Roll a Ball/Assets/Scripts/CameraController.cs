using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //Public Variables
    public GameObject player;

    //Private Variables
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}

    // Update is called once per frame
    // LateUpdate is used for Follow Cameras, Proceedional Animation and Gathering Last Known States.
    void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

    
}
