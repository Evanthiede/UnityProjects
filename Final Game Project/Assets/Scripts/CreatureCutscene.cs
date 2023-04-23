using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCutscene : MonoBehaviour
{
    public Animator creature;
    public GameObject antelers;
    public Transform player;
    public GameObject barrier;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        creature = gameObject.GetComponent<Animator>();
        antelers.SetActive(false);
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void Animate()
    { 
        antelers.SetActive(true);
        creature.Play("A pear");
    
        if (timer > 7)
        {
            barrier.SetActive(false);
        }
    }
}
