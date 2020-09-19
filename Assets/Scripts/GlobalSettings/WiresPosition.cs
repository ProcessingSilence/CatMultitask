using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresPosition : MonoBehaviour
{
    public Transform[] currentWirePositions;
    

    public static class Wires
    {
        public static Transform[] WireTransforms;
    }

    void Awake()
    {
        Wires.WireTransforms = currentWirePositions;
        for (int i = 0; i < Wires.WireTransforms.Length; i++)
        {
            Debug.Log(Wires.WireTransforms[i].position);
        }

        Debug.Log(Wires.WireTransforms.Length);
    }
}
