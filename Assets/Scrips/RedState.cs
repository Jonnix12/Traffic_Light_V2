using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedState : TrafficLightStateBaseClass
{
    public override void StartTheState(MeshRenderer renderer, float time)
    {
        color = Color.red;
        
        base.renderer = renderer;

        base.time = time;
    }
}
