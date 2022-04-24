using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    private TrafficLightStateBaseClass _currentState;

    private readonly TrafficLightStateBaseClass[] _states = {
        new RedState(),new YellowState(), new GreenState()
    };
    
    [SerializeField] private MeshRenderer _redLight;
    [SerializeField] private MeshRenderer _yellowLight;
    [SerializeField] private MeshRenderer _greenLight;
    
    [SerializeField] private float _redTime;
    [SerializeField] private float _yellowTime;
    [SerializeField] private float _greenTime;

    private int _currentStateIndex = 0;

    private bool _isWorking = false;
    
    void Start()
    {
        _states[0].StartTheState(_redLight,_redTime);
        _states[1].StartTheState(_yellowLight,_yellowTime);
        _states[2].StartTheState(_greenLight,_greenTime);
        
        if (_isWorking)
        {
            _currentState = _states[_currentStateIndex];
            StartCoroutine(_currentState.DelayForLight(_currentState,this));
        }
    }

    
    public void NextState()
    {
        if(!_isWorking) return;
        
        if (_currentStateIndex >= 2)
        {
            _currentStateIndex = 0;
        }
        else
        {
            _currentStateIndex++;
        }

        _currentState = _states[_currentStateIndex];
        StartCoroutine(_currentState.DelayForLight(_currentState,this));
    }

    [ContextMenu("Start")]
    public void SetOn()
    {
        _isWorking = true;
        _currentState = _states[_currentStateIndex];
        StartCoroutine(_currentState.DelayForLight(_currentState,this));
    }

    [ContextMenu("End")]
    public void SetOff()
    {
        _isWorking = false;
        ResetBody();
    }

    private void ResetBody()
    {
        _redLight.material.color = Color.white;
        _yellowLight.material.color = Color.white;
        _greenLight.material.color = Color.white;
        _currentStateIndex = 0;
        StopAllCoroutines();
    }
}
