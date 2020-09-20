using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enables controls if player sits in chair.
// Disables controls if player standing.
public class AllowGameMovement : MonoBehaviour
{
    private VgPlayerMovement _vgPlayerMovement_script;

    public bool allowControls;


    void Awake()
    {
        _vgPlayerMovement_script = gameObject.GetComponent<VgPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        allowControls = Chair.IsSitting.sitCheck;
        _vgPlayerMovement_script.enabled = allowControls;
    }
}
