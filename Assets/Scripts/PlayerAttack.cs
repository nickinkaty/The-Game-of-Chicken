using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform FirePosition;
    public GameObject projectile;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            Instantiate(projectile, FirePosition.position, FirePosition.rotation);
        }
        
    }
}
