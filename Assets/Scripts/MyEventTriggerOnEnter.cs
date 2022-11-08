using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventTriggerOnEnter : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;
    private bool checkpointreached = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else
        {
            if(checkpointreached == false){
                print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
                myEvents.Invoke();
                checkpointreached = true;
            }
        }
    }
}