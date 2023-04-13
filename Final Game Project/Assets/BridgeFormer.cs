using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeFormer : MonoBehaviour
{
    public GameObject bridge;
    public bool bridgeTriggered;
    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        bridge.SetActive(true);
        bridgeTriggered = true;

    }
}
