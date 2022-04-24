using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowState : TrafficLightStateBaseClass
{
    public override void StartTheState(MeshRenderer renderer, float time)
    {
        color = Color.yellow;
        
        base.renderer = renderer;

        base.time = time;
    }
}
