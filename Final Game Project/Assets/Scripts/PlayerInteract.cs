using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
               if(collider.TryGetComponent(out PillarBehaviors pillarBehavior))
                {
                    pillarBehavior.GatewayOpen();
                }
                if (collider.TryGetComponent(out BallActivation ballActivation))
                {
                    ballActivation.BallActivate();
                }
                if (collider.TryGetComponent(out BridgeFormer bridgeFormer))
                {
                    bridgeFormer.BuildBridge();
                }
                if (collider.TryGetComponent(out GameEnd gameEnd))
                {
                    gameEnd.FinishGame();
                }

            }
        }
    }
}
