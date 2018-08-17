using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public GameObject player;
    public Vector3 startPos;
    public Vector3 endPos;
    public float distance = 1.0f;
    public float lerpTime = 1f;
    private float currentLerpTime = 0;
    private bool keyHit = false;
    private bool isMoving = false;


	// Use this for initialization
	void Start () {
        startPos = player.transform.position;
        endPos = player.transform.position + Vector3.left * distance;
    }

    // Update is called once per frame
    void Update () {

        

        if (Input.GetKeyDown(KeyCode.A) && keyHit == false) {
                player.transform.position = Vector3.Lerp(startPos, endPos, lerpTime * Time.deltaTime);
                
        }
            
        
       
    }
}
