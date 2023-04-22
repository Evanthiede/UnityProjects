using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarActivation : MonoBehaviour
{

    public bool tripped;
    public ParticleSystem sparkle;
    public Material deacitivatedCrystal;
    public Material activeCrystal;
    public GameObject cube;
    public ParticleSystem flash;


    // Start is called before the first frame update
    void Start()
    {
        sparkle.Play();
        tripped = false;
        

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        tripped = true;
        sparkle.Stop();
        


    }
}
