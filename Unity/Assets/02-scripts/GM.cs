using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

		public static float vertVel=0;
		public static int coinTotal = 0;
		public static float timeTotal = 0;
		public static float zVelAdj = 1; // Z achse velocity
	
	// Update is called once per frame
	void Update () {
		timeTotal += Time.deltaTime;
	}
}
