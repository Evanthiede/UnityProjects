using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultOpen : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public ParticleSystem darkness;
    public ParticleSystem flash;
    public AudioSource gong;

    private void Start()
    {
        darkness.Stop();
        flash.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        door1.SetActive(false);
        door2.SetActive(false);
        darkness.Play();
        flash.Play();
        gong.pitch = (Random.Range(0.95f, 1.05f));
        gong.Play();
    }
}
