using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivation : MonoBehaviour
{
    public ParticleSystem flash;
    public GameObject Companion;
    public AudioSource gong;


    // Start is called before the first frame update
    void Start()
    {
        Companion.SetActive(false);
        flash.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Companion.SetActive(true);
        flash.Play();
        gong.pitch = (Random.Range(0.95f, 1.05f));
        gong.Play();

    }
}
