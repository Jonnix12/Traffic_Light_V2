using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    private TrafficLightStateBaseClass _currentState;//A variable to hold the currentstat 
    
    //A array to hold all of the state reference
    private readonly TrafficLightStateBaseClass[] _states =
    {
        new RedState(), new YellowState(), new GreenState()
    };

    [SerializeField] private MeshRenderer _redLight;
    [SerializeField] private MeshRenderer _yellowLight;
    [SerializeField] private MeshRenderer _greenLight;

    [SerializeField] private float _redTime;
    [SerializeField] private float _yellowTime;
    [SerializeField] private float _greenTime;

    private int _currentStateIndex = 0;//A index that represents the currnt state index

    private bool _isWorking = false;// A bool to set the on or off state

    void Start()
    {
        //in each state I call the init State function to set the meshrenderer and the timer
        _states[0].InitState(_redLight, _redTime);
        _states[1].InitState(_yellowLight, _yellowTime);
        _states[2].InitState(_greenLight, _greenTime);
        
        //check if isWorking is true and if it is set the first state ant call the first coroutine
        if (_isWorking)
        {
            _currentState = _states[_currentStateIndex];
            StartCoroutine(_currentState.DelayForLight(_currentState, this));
        }
    }


    public void NextState()// A function that increment the stateIndex an start the next coroutine
    {
        if (!_isWorking) return;

        if (_currentStateIndex >= 2)
        {
            _currentStateIndex = 0;
        }
        else
        {
            _currentStateIndex++;
        }

        _currentState = _states[_currentStateIndex];
        StartCoroutine(_currentState.DelayForLight(_currentState, this));
    }

    [ContextMenu("Start")]
    public void SetOn()
    {
        _isWorking = true;
        _currentState = _states[_currentStateIndex];
        StartCoroutine(_currentState.DelayForLight(_currentState, this));
    }

    [ContextMenu("Stop")]
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