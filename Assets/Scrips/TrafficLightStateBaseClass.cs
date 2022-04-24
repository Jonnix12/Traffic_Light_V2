using System.Collections;
using UnityEngine;

public abstract class TrafficLightStateBaseClass
{
   protected Color color;

   protected MeshRenderer renderer;

   protected float time;
   
   public abstract void StartTheState(MeshRenderer renderer, float time);

   public IEnumerator DelayForLight(TrafficLightStateBaseClass state,TrafficLightManager manager)
   {
      state.renderer.material.color = state.color;
      yield return new WaitForSeconds(state.time);
      state.renderer.material.color = Color.white;
      manager.NextState();
   }
   
}
