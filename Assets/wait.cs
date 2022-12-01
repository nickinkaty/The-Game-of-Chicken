using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class wait : MonoBehaviour
{

    public float wait_time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(1);
    }
    
}
