using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SideScrolling : MonoBehaviour
{
    private new Camera camera;
    private Transform player;

    public float height = 6.5f;

    public int minX = -3;
    public int minY  = -3;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // track the player moving to the right
        // transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); 
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(minX, player.position.x);
        cameraPosition.y = Mathf.Max(minY, player.position.y);
        transform.position = cameraPosition;
    }

}