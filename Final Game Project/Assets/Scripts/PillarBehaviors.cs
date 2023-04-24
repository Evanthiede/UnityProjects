using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PillarBehaviors : MonoBehaviour
{
    public Collider pillarTrigger;
    public GameObject gatewayRock;
    public bool triggered;
    public ParticleSystem flash;
    public AudioSource gong;

    private void Start()
    {
        flash.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        gatewayRock.SetActive(false);
        triggered = true;
        gong.pitch = (Random.Range(0.95f, 1.05f));
        flash.Play();
        gong.Play();
    }
}
