using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TurnColiderOnClickButtonTeleport : MonoBehaviour
{
    // Script on custom hand.


    /// <summary>
    /// Name parent object
    /// </summary>
    private string nameParent;
    /// <summary>
    /// Array colliders in object
    /// </summary>
    [SerializeField] private Collider[] colliders;

    /// <summary>
    /// Get name parent. 
    /// Debug: print in console text which name parent
    /// </summary>
    private void Start()
    {
        nameParent = transform.parent.name;
        print($"Parent: {nameParent}");
    }

    private void Update()
    {
        TurnColliders();
    }

    /// <summary>
    /// Turn colliders in object
    /// 
    /// Check name parent.
    /// This is necessary in order to understand which hand the player pressed the button with.
    /// </summary>
    private void TurnColliders()
    {
        switch (nameParent)
        {
            case "RightHand":
                if(SteamVR_Input.GetStateDown("Teleport", SteamVR_Input_Sources.RightHand))
                {
                    foreach (var collider in colliders)
                    {
                        collider.enabled = false;
                    }
                }
                else if (SteamVR_Input.GetStateUp("Teleport", SteamVR_Input_Sources.RightHand))
                {
                    foreach(var collider in colliders)
                    {
                        collider.enabled = true;
                    }
                }
                break;
            case "LeftHand":
                if (SteamVR_Input.GetStateDown("Teleport", SteamVR_Input_Sources.LeftHand))
                {
                    foreach (var collider in colliders)
                    {
                        collider.enabled = false;
                    }
                }
                else if (SteamVR_Input.GetStateUp("Teleport", SteamVR_Input_Sources.LeftHand))
                {
                    foreach (var collider in colliders)
                    {
                        collider.enabled = true;
                    }
                }
                break;
        }
    }
}
