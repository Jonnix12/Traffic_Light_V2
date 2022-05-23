using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    //A array to hold all of the state reference
    [SerializeField] private TrafficLightStateBaseClass[] _states;
    
    private int _currentStateIndex = 0;//A index that represents the currnt state index

    private bool _isWorking = false;// A bool to set the on or off state
    

    [ContextMenu("Start")]
    public void SetOn()
    {
        _isWorking = true;
        StartCoroutine(TrafficLihgtCycle());
    }

    [ContextMenu("Stop")]
    public void SetOff()
    {
        _isWorking = false;
        ResetBody();
    }

    private void ResetBody()
    {
        _currentStateIndex = 0;
        StopAllCoroutines();
    }

    private IEnumerator TrafficLihgtCycle()
    {
        while (_isWorking)
        {
            yield return _states[_currentStateIndex].DelayForLight();

            if (_currentStateIndex < _states.Length - 1)
            {
                _currentStateIndex++;
            }
            else
            {
                _currentStateIndex = 0;
            }
        }
    }
}