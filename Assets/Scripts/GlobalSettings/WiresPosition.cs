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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
