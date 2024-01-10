#pragma strict

function Start () {
	
}

function Update () {
	if (transform.position.x > 45)
			transform.position.x = 45;

		if (transform.position.x < -10)
			transform.position.x = -10;

		if (transform.position.z > 30)
			transform.position.z = 30;

		if (transform.position.z < -30)
			transform.position.z = -30;
}
