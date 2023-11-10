using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Tower;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Touch on " + hit.transform.name);
                    Tower.GetComponent<TurretAI>().currentTarget = hit.transform.gameObject;
                    Tower.GetComponent<TurretAI>().Shoot(hit.transform.gameObject); 
                }
                else
                {
                    Debug.Log("Nothing hitted Baby"); 
                }
            }

        }


        
    }
}
