using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour
{
    // Variables

    public GameObject myParticleSystem;

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update ()
    {

    
    }

    // On any collision of object
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Trigger Detected!!");
        myParticleSystem.GetComponent<ParticleSystem>().Play();
    }


}
