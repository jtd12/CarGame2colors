using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restart1 : MonoBehaviour
{
 
    public float seconds=0;
    public int timer = 10;
    public Text gui;
    public Text guiTimer;
    public Car1 car;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seconds -= 0.01f;
        timer -= 1;
        gui.text = seconds.ToString();
        if(timer>=0)
        {
            guiTimer.enabled = true;
            guiTimer.text = timer.ToString();
            
        }
        else
        {
            guiTimer.enabled = false;
        }
        
      
       if(seconds < 0 && car.points < 0)
        {
            Application.LoadLevel(2);
        }
        else if (seconds < 0)
        {
            Application.LoadLevel(2);
        }
        else if(car.points < 0)
        {
            Application.LoadLevel(2);
        }
    }

  
}
