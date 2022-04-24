using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    private TrafficLightStateBaseClass currentState;

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
    
    void Start()
    {
        _states[0].StartTheState(_redLight,_redTime);
        _states[1].StartTheState(_yellowLight,_yellowTime);
        _states[2].StartTheState(_greenLight,_greenTime);
        
        currentState = _states[_currentStateIndex];
        StartCoroutine(currentState.DelayForLight(currentState,this));
    }

    
    public void NextState()
    {
        if (_currentStateIndex >= 2)
        {
            _currentStateIndex = 0;
        }
        else
        {
            _currentStateIndex++;
        }

        currentState = _states[_currentStateIndex];
        StartCoroutine(currentState.DelayForLight(currentState,this));
    }
}
