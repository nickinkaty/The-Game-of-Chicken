using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public HealthSystem healthSystem;
    public static bool isPauseMenu;
    public GameObject pauseMenu;

    public static Vector2 lastCheckPointPos = new Vector2(-5, -5);

    private void Awake()
    {
        isPauseMenu = false;

        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnPlayer();
        activatePauseScreen();
    }

    void activatePauseScreen()
    {
        if (Input.GetKey("escape")  && pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(true);
        }
    }

    void respawnPlayer()
    {
        if (healthSystem.currentHealth <= 0)
        {
            Animator Animator = healthSystem.GetComponent<Animator>();
            Animator.SetTrigger("isDead");
            StartCoroutine(respawn());
            healthSystem.setHealth(100);
        }
    }
    IEnumerator respawn()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
}
