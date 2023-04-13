using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    public CreatureCutscene cutscene;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        cutscene.Animate();
        
    }
}
