using System.Collections;
using UnityEngine;

public abstract class TrafficLightStateBaseClass
{
   protected Color Color;

   protected MeshRenderer Renderer;

   protected float Time;
   
   public abstract void InitState(MeshRenderer renderer, float time);

   //A coroutine that set the light to the correct color and set it off after the set time
   public IEnumerator DelayForLight(TrafficLightStateBaseClass state,TrafficLightManager manager)
   {
      var materialLight = state.Renderer.material;//set the current material state
      
      materialLight.color = state.Color;
      yield return new WaitForSeconds(state.Time);//wait
      materialLight.color = Color.white;
      
      manager.NextState();//call the next state 
   }
   
}
