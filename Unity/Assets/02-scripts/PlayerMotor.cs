using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour {

    public Transform player;

    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;


    public float speed; //= 5.0f; // Schnelligkeit festelgen auf 5m pro sekunde

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    // Horizontale Bewegung
    private Vector3 playerPos;
    public float horizontalSpeed = 2f;



    private float animationDuration = 3.0f; //spieler darf in ersten 3 sek nicht bewegen
    private float startTime; // damit der spieler sich am anfang nicht bewegt

    Animator mAnimator;
    private bool isDead = false;
    
    public Text sterntext;
    public float sternzaehler;

    public float cubeGroesse = 0.2f;

    public float delay = 3f;
    private float countdown;

    public Highscore myHighscore;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();
        startTime = Time.time;
		speedMilestoneCount = speedIncreaseMilestone;
        mAnimator = GetComponent<Animator>();

        sternzaehler = 100f;
        countdown = delay;

        //highScore = player.GetComponent<Highscore>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                myHighscore.OnDeath(); // wenn spieler tot ist kommt nach 3 sekunden das death menu
            }
            return;
        }

        if (Time.time - startTime < animationDuration) { //damit der spieler sich nicht am anfang bewegt
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded) // wenn Spieler auf Boden ist
        {
            verticalVelocity = -0.5f; //Spieler faellt nicht wird nur auf Boden gedrückt
        } else //nicht auf Boden
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Bewegung Horizontal
        if (Input.GetKeyDown(KeyCode.A)) {
            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(-1f, 0, 0), horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(1f, 0, 0), horizontalSpeed * Time.deltaTime);
        }

        //Vektoren jedes mal neu berechnen
        //X - Left and Right
        //moveVector.x = Input.GetAxisRaw("Horizontal")* speed; //Spieler kann rechts und links gehen
        //Y - Up and Down
        moveVector.y = verticalVelocity;
        //Z - Foward and Backward
        moveVector.z = speed; 

        controller.Move(moveVector * Time.deltaTime); //Spieler bewegen, Time.deltaTime damit er nicht so schnell lauft
        //PositionChanging();


        if (transform.position.z > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed + speedMultiplier;
        }
        
        sternzaehler -= 0.2f; // die zahl des Wassers was der kaktus hat wird immer weniger, er muss flaschen sammeln damit er nicht stirbt

        if(sternzaehler <= 0f){
            myHighscore.OnDeath();
        }
        //STERNCHEN ANZEIGE
        sterntext.text = ((float)sternzaehler).ToString();
       
        

    }



    //aufruf jedes mal wenn der Spieler etwas beruehrt
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
        //STERN
         if (hit.gameObject.tag == "Stern")
        {
            sternzaehler += 10;
            //Stern verschwindet
            Destroy(hit.gameObject);
            Debug.Log(sternzaehler);
        }

         //EINBRECHEN   
        Rigidbody body = hit.collider.attachedRigidbody;
        GameObject obstacle = hit.collider.gameObject; //speichert das obstacle auf das der spieler trifft ind obstacle
         if (hit.gameObject.tag == "einbrechen")
        {

            //brechen(obstacle); //uebergibt das getroffene obstacle an brechen()
            obstacle.SetActive(false);
            

            mAnimator.SetBool("dead", true);
            isDead = true;
        }
        
    }
    
    
    public void brechen(GameObject obj)
    {
        //obj.SetActive(false); //grosse Platte verschwinden, das machen e´bei einbrechen
        
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 2; z++)
                {
                    createTeile(x, y, z, obj);
                }
            }
        }

        //obj.SetActive(false); //grosse Platte verschwinden
    }

    void createTeile(int x, int y, int z, GameObject obj)
        {
            GameObject teilchen;
            teilchen = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            teilchen.transform.position = obj.transform.position + new Vector3(cubeGroesse * x, cubeGroesse*y , cubeGroesse * z);
            teilchen.transform.localScale = new Vector3(cubeGroesse, cubeGroesse, cubeGroesse);

            teilchen.AddComponent<Rigidbody>();
            teilchen.GetComponent<Rigidbody>().mass = cubeGroesse;
            

    }


    public void Death() {
        //myHighscore.OnDeath();
    }





    /* IEnumerator MoveFromTo(Transform thisPlayer, Vector3 a, Vector3 b, float horizontalSpeed) {
       float step = (horizontalSpeed / (a - b).magnitude) * Time.fixedDeltaTime;
       float t = 0;
       while (t <= 1.0f) {
           t += step;
           thisPlayer.position = Vector3.Lerp(a, b, t); 
           yield return new WaitForFixedUpdate();         
       }
       thisPlayer.position = b;
   }*/


    /*
    void Awake() {
        newPosition = player.transform.position;
    }

    void PositionChanging() {
        Vector3 positionA = player.transform.position + new Vector3(-1f, 0f, 0f);
        Vector3 positionB = player.transform.position + new Vector3(1f, 0f, 0f);


        if (Input.GetKeyDown(KeyCode.A)) {
            newPosition = positionA;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            newPosition = positionB;
        }

        player.transform.position = Vector3.Lerp(player.transform.position, newPosition, Time.deltaTime * speed);
    }
    */

}
