using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPoint : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            //  other.transform.position = new Vector3(90, 80, -3883);
            other.GetComponent<Car1>().points+=10;
        }
    }
}
