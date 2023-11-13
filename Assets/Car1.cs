using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Car1 : MonoBehaviour
{
    public float maxTorque = 50f;
	private float currentSpeed=0.0f;
    public Transform centerOfMass;
	public Text guiSpeed;
    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] tireMeshes = new Transform[4];
	public float lowspeedangle = 0.0f;
	public float hightspeedangle=0.0f;
    private Rigidbody m_rigidBody;
	public int[] gearRatio;
	private  AudioSource au_;
	public float topSpeed=0.0f;
	public bool changeScene = false;
	public bool speedLimit = false;
	//public restart1 res;
	public Camera cam1;
	public Camera cam2;
	public int camInc = 0;
	public Transform resetPos;
	public int points = 300;
	public Text pointsText;
	public restart1 res;
	public GameObject motor;
	void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.centerOfMass = centerOfMass.localPosition;
		au_=GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateMeshesPositions();

    }

	public void damage(int p)
    {
		points-=p;
		motor.GetComponent<ParticleSystem>().startSpeed += 0.5f;
    }

	void FixedUpdate()
	{
		
		if (res.guiTimer.enabled == false)
		{

			float speedCar = m_rigidBody.GetComponent<Rigidbody>().velocity.magnitude;


			if(transform.rotation.z<-0.5f)
            {
				transform.rotation = Quaternion.Euler(  transform.rotation.x, transform.rotation.y, -0.5f);
            }
			if (transform.rotation.z > 0.5f)
			{
				transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0.5f);
			}

			if (speedCar < 5.09f)
			{
				speedLimit = true;
			}
			else
			{
				changeScene = false;
				speedLimit = false;
			}
			if (speedLimit)
			{
				StartCoroutine(coroutine());
				StartCoroutine(coroutine1());
			}


			//StartCoroutine(Coroutine1());
			engineSound();
			changeCam();
			resetPosition();

			guiSpeed.text = currentSpeed.ToString();
			pointsText.text = points.ToString();

			float speedFactor = m_rigidBody.velocity.magnitude;
			currentSpeed = (Mathf.PI * 2 * wheelColliders[0].radius) * wheelColliders[0].rpm * 100 / 10000;
			float currentsteerangle = Mathf.Lerp(lowspeedangle, hightspeedangle, speedFactor);
			currentsteerangle *= Input.GetAxis("Horizontal");
			float accelerate = Input.GetAxis("Vertical");


			wheelColliders[0].steerAngle = currentsteerangle;
			wheelColliders[1].steerAngle = currentsteerangle;
			if (currentSpeed < topSpeed)
			{
				if (accelerate > 0f || accelerate < 0f)
				{
					for (int i = 0; i < 4; i++)
					{
						wheelColliders[i].motorTorque = accelerate * maxTorque;
						wheelColliders[i].brakeTorque = 0;



						if (accelerate == 0f)
						{

							wheelColliders[i].brakeTorque = 20000;
						}
						if (Input.GetAxis("Jump") > 0.1)
						{

							wheelColliders[i].brakeTorque = 55000;
						}
					}
				}
				else
				{
					wheelColliders[0].motorTorque = 0;
					wheelColliders[1].motorTorque = 0;
				}

			}

		}
		
	}
	void engineSound()
	{
		if (currentSpeed < 350)
		{
			au_.pitch = currentSpeed / topSpeed + 1;
		}
		else
		{
			au_.pitch = 0;

		}

	}
    void UpdateMeshesPositions()
    {
        for(int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            tireMeshes[i].position = pos;
            tireMeshes[i].rotation = quat*Quaternion.Euler(0,90,0);
        }
    }
	
	void changeCam()
	{
		if (Input.GetAxis("cam")>0.1)
		{
			camInc += 1;
			if (camInc > 5)
				camInc = 0;
			if (camInc < 3)
			{
				cam1.gameObject.SetActive(true);
				cam2.gameObject.SetActive(false);
			}
			else
			{
				cam1.gameObject.SetActive(false);
				cam2.gameObject.SetActive(true);
			}
		}


	}

	IEnumerator coroutine()
	{

		if (speedLimit)
		{
			yield return new WaitForSeconds(2);

			changeScene = true;
		}


	}

	IEnumerator coroutine1()
	{
		if (speedLimit)
		{
			if (changeScene)
			{
				yield return new WaitForSeconds(3);

				changeScene = false;
			}
		}


	}

	private void resetPosition()
	{


		if (changeScene)
		{
			transform.position = resetPos.position;
			transform.rotation = resetPos.rotation;
		}

	}

}
