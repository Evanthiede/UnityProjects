using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCutscene : MonoBehaviour
{
    public Animator creature;
    public GameObject antelers;
    public Transform player;
    public Transform SceneBox;

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

        player.transform.position = SceneBox.transform.position;


    }
}
