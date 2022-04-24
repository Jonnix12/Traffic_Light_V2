using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedState : TrafficLightStateBaseClass
{
    public override void InitState(MeshRenderer renderer, float time)
    {
        Color = Color.red;
        
        base.Renderer = renderer;

        base.Time = time;
    }
}
