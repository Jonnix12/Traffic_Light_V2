using UnityEngine;

public class GreenState : TrafficLightStateBaseClass
{
    public override void InitState(MeshRenderer renderer, float time)
    {
        Color = Color.green;
        
        base.Renderer = renderer;

        base.Time = time;
    }
}
