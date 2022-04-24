using UnityEngine;

public class GreenState : TrafficLightStateBaseClass
{
    public override void StartTheState(MeshRenderer renderer, float time)
    {
        color = Color.green;
        
        base.renderer = renderer;

        base.time = time;
    }
}
