using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultOpen : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public ParticleSystem darkness;

    private void Start()
    {
        darkness.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        door1.SetActive(false);
        door2.SetActive(false);
        darkness.Play();

    }
}
