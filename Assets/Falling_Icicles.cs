using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Falling_Icicles : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {  
        rigidbody = GetComponent<Rigidbody2D> ();
    }

    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.name.Equals ("Ranger"))
            rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D obj)
    {
        if (obj.gameObject.name.Equals ("Ranger"))
            Destroy(gameObject);
    }
}
 