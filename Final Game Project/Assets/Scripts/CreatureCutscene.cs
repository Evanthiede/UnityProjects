using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCutscene : MonoBehaviour
{
    public Animator creature;
    public GameObject antelers;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        creature = gameObject.GetComponent<Animator>();
        antelers.SetActive(false);
        
    }

    public void Animate()
    { 
        antelers.SetActive(true);
        creature.Play("A pear");

    }
}
