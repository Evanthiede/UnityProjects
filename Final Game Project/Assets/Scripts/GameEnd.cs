using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ended");

    }
}
