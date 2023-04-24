using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeFormer : MonoBehaviour
{
    public GameObject bridge;
    public bool bridgeTriggered;
    public GameObject barrier;
    public ParticleSystem flash;
    public AudioSource gong;

    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
        flash.Stop();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        bridge.SetActive(true);
        bridgeTriggered = true;
        barrier.SetActive(false);
        flash.Play();
        gong.pitch = (Random.Range(0.95f, 1.05f));
        gong.Play();
    }
}
