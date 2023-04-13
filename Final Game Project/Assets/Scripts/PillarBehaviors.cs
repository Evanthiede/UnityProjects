using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PillarBehaviors : MonoBehaviour
{
    public Collider pillarTrigger;
    public GameObject gatewayRock;
    public bool triggered;


    private void OnTriggerEnter(Collider other)
    {
        gatewayRock.SetActive(false);
        triggered = true;

    }
}
