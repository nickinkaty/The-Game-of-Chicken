using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public EnergySystem energySystem;
    public Transform FirePosition;
    public GameObject projectile;
    public GameObject egg;
    public Animator Animator;

    public static float fireballEnergy = 20.0f;
    public static float eggBombEnergy = 30.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.GameIsPaused){
            if (Input.GetKeyDown(KeyCode.Mouse0) && energySystem.currentEnergy >= fireballEnergy)
            {
                AudioManagerScript.PlaySound("fireball");
                energySystem.LoseEnergy(fireballEnergy);
                Instantiate(projectile, FirePosition.position, FirePosition.rotation);
            }

            if(Input.GetKeyDown(KeyCode.Mouse1) && energySystem.currentEnergy >= eggBombEnergy)
            {
                AudioManagerScript.PlaySound("egg");
                energySystem.LoseEnergy(eggBombEnergy);
                Animator.SetTrigger("EggBombing");
                StartCoroutine(InstantiateEgg());
            }
        }

    }
    IEnumerator InstantiateEgg()
    {
        yield return new WaitForSeconds(.8f);
        Instantiate(egg, FirePosition.position, FirePosition.rotation);
    }
}
