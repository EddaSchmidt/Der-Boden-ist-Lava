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

    //damit man weiss wie der spieler stirbt um bestimmte animation spielen zu lassen
    private bool verdurstet = false;
    public bool runtergefallen = false;
    public bool verbrannt = false;

    public Text todesursache; //public Highscore myHighscore;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();
        startTime = Time.time;
		speedMilestoneCount = speedIncreaseMilestone;
        mAnimator = GetComponent<Animator>();

        sternzaehler = 100f;
        countdown = delay;
    }
	
	// Update is called once per frame
	void Update () {

        if (verbrannt == true) {
            todesursache.text = "Kaktus wurde von der Fontäne gegrillt.";
        }
        if (verdurstet == true) {
            todesursache.text = "Kaktus ist vertrocknet. Sammle mehr Wasserflaschen.";
        }
        if (runtergefallen == true) {
            todesursache.text = "Kaktus ist vom Weg abgekommen und wurde gegrillt.";
        }
        if (isDead) {
            countdown -= Time.deltaTime;
            if (countdown <= 0) {
                //myHighscore.OnDeath(); 
                Death(); // wenn spieler tot ist kommt nach 3 sekunden das death menu
            }
            return;
        }

        if (Time.time - startTime < animationDuration) { //damit der spieler sich nicht am anfang bewegt
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded) {                    // wenn Spieler auf Boden ist        
            verticalVelocity = -0.5f;                   //Spieler faellt nicht wird nur auf Boden gedrückt
        } else {                                        //nicht auf Boden
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Bewegung Horizontal
        if (Input.GetKeyDown(KeyCode.A)) {
            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(-1f, 0, 0), horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(1f, 0, 0), horizontalSpeed * Time.deltaTime);
        }

        if (player.transform.position.x <= -3f) {       //wenn spieler vom feld runter geht
            isDead = true;                              // dann spieler tot 
            mAnimator.SetBool("verdurstet", true);      // animation wird gestartet
            runtergefallen = true;                      //damit die eine animation ausgelassen wird und der spieler direkt umfaellt!
        }

        if (player.transform.position.x >= 3f) {        //wenn spieler vom feld runter geht
            isDead = true;                              // dann spieler tot 
            mAnimator.SetBool("verdurstet", true);      // animation wird gestartet
            runtergefallen = true;
        }

        //Vektoren jedes mal neu berechnen
        moveVector.y = verticalVelocity;                //Y - Up and Down
        moveVector.z = speed;                           //Z - Foward and Backward

        controller.Move(moveVector * Time.deltaTime);   //Spieler bewegen, Time.deltaTime damit er nicht so schnell lauft

        if (transform.position.z > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed + speedMultiplier;
        }
        
        sternzaehler -= 0.2f;                           // die zahl des Wassers was der kaktus hat wird immer weniger, er muss flaschen sammeln damit er nicht stirbt

        if(sternzaehler <= 0f) {
            //myHighscore.OnDeath();
            isDead = true;                              // dann spieler tot 
            mAnimator.SetBool("verdurstet", true);      // animation wird gestartet
            verdurstet = true;                          // damit anzeige kommen kann das spieler verdurstet ist 
        }        
        sterntext.text = ((int)sternzaehler).ToString();//STERNCHEN ANZEIGE
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

        //EINBRECHEN bzw. brauchen wir auch für die Fontänen!  
        Rigidbody body = hit.collider.attachedRigidbody;
        GameObject obstacle = hit.collider.gameObject;  //speichert das obstacle auf das der spieler trifft ind obstacle
         if (hit.gameObject.tag == "einbrechen") {

            //brechen(obstacle); //uebergibt das getroffene obstacle an brechen()
            obstacle.SetActive(false);            

            mAnimator.SetBool("verbrannt", true);
            isDead = true;
            verbrannt = true;
        }
        
    }

    public void Death() {
        GetComponent<Highscore>().OnDeath(); // das death menu wird aufgerufen, mehr macht das nicht und das mit einer verzoegerung von 3 sek
        //myHighscore.OnDeath();
    }


    //EINBRECHEN, wird dafür benötigt aber haben das ja nicht mehr
    /*
    public void brechen(GameObject obj)
    {
        //obj.SetActive(false); //grosse Platte verschwinden, das machen e´bei einbrechen
        
        for (int x = 0; x < 2; x++) {
            for (int y = 0; y < 5; y++) {
                for (int z = 0; z < 2; z++) {
                    createTeile(x, y, z, obj);
                }
            }
        }
        //obj.SetActive(false); //grosse Platte verschwinden
    }

    void createTeile(int x, int y, int z, GameObject obj) {
        GameObject teilchen;
        teilchen = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        teilchen.transform.position = obj.transform.position + new Vector3(cubeGroesse * x, cubeGroesse*y , cubeGroesse * z);
        teilchen.transform.localScale = new Vector3(cubeGroesse, cubeGroesse, cubeGroesse);

        teilchen.AddComponent<Rigidbody>();
        teilchen.GetComponent<Rigidbody>().mass = cubeGroesse;
    }
    */
}
