using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    public Camera cam;
    public Transform player;
    public float parallaxFactor;
    Vector2 startPos;
    float startZ;
    float startY;

    Vector2 travel => (Vector2)cam.transform.position - startPos;
    float distanceFromSubject => transform.position.z - player.position.z; 
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPos = startPos + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, startY, startZ);
    }
}
