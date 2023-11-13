using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBar : MonoBehaviour
{
    public GameObject[] bar;
   
    //AnimationState anim;
    // Start is called before the first frame update
    void Start()
    {
       // bar[0].GetComponent<Animator>().PlayInFixedTime("barrieres", 0, 1.5f);
        // bar[0].GetComponent<Animator>().Play("barrieres", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bar.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, bar[i].transform.position);

            float time = GetCurrentAnimatorTime(bar[i].GetComponent<Animator>(), 0);
            float time2 = GetCurrentAnimatorTime(bar[i].GetComponent<Animator>(), 0);

            if (dist < 450.0f)
            {
                if (time < 0.9f && time2 < 0.9f)
                {
                    bar[i].GetComponent<Animator>().enabled = true;
                    bar[i].GetComponent<Animator>().enabled = true;
                    //bar[0].GetComponent<Animator>().speed = 0;
                    //bar[0].GetComponent<Animator>().Play("barrieres",0,0.1f);

                }



                else
                {
                    bar[i].GetComponent<Animator>().enabled = false;
                    bar[i].GetComponent<Animator>().enabled = false;
                }
            }

            else
            {
                if (time < 0.4f && time2 < 0.4f)
                {
                    bar[i].GetComponent<Animator>().enabled = false;
                    bar[i].GetComponent<Animator>().enabled = false;
                }
                else
                {
                    bar[i].GetComponent<Animator>().enabled = true;
                    bar[i].GetComponent<Animator>().enabled = true;
                }

            }
        }
      

    }

    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }






}
