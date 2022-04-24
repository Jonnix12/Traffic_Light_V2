using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowState : TrafficLightStateBaseClass
{
    public override void InitState(MeshRenderer renderer, float time)
    {
        Color = Color.yellow;
        
        base.Renderer = renderer;

        base.Time = time;
    }
}
