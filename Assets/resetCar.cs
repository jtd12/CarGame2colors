using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCar : MonoBehaviour
{
    public Transform resetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.transform.position = resetPos.position;
            other.transform.rotation = resetPos.rotation;

            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }
}
