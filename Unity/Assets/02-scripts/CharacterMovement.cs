using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public GameObject player;


    public IEnumerator Start () {
        if (Input.GetKeyDown(KeyCode.A)) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position + Vector3.left * 2, 20f * Time.deltaTime);
        }
        yield return null;
    }

    /*
    public Transform startPos;
    public Transform endPos;
    public bool repeatable = false;
    public float speed = 40f;
    public float lerpTime = 20.0f;

    private float startTime;
    private float totalDistance;

    IEnumerator Start() {
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos.position, endPos.position);

        while (repeatable) {
            yield return RepeatLerp(startPos.position, endPos.position, lerpTime);
            yield return RepeatLerp(endPos.position, startPos.position, lerpTime);
        }
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            if (!repeatable) {
                float currentDuration = (Time.time - startTime) * speed;
                float journeyFraction = currentDuration / totalDistance;
                this.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
            }
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {
        float i = 0;
        float rate = (1f / time) * speed;
        while (i < 1f) {
            i = i + Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }

    }*/









































    /* public GameObject player;
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
            
        
       
    } */
}
