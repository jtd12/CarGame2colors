using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceField : MonoBehaviour
{
    public GameObject player;
    private GameObject[] g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            g = GameObject.FindGameObjectsWithTag("batiments");

        for (int i = 0; i < g.Length; i++)
        {
           float distance = Vector3.Distance(g[i].transform.position, player.transform.position);

            if (distance < 4500)
            {
                g[i].transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
               

            }
            else
            {
                g[i].transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
      
            }
        }
    }
}
