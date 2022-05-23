using System.Collections;
using UnityEngine;

[System.Serializable]
public abstract class TrafficLightStateBaseClass
{
   [SerializeField] protected Color color;

   [SerializeField] protected MeshRenderer renderer;

   [SerializeField] protected float time;
   
   //A coroutine that set the light to the correct color and set it off after the set time
   public virtual IEnumerator DelayForLight()
   {
      var materialLight = renderer.material;//set the current material state
      materialLight.color = color;
      yield return new WaitForSeconds(time);//wait
      materialLight.color = Color.white;
   }
   
}
