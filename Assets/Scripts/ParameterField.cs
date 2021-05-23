using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The class of input fields (game properties).
/// </summary>
public class ParameterField : MonoBehaviour
{
    [SerializeField]private Text _inputParameter = null; // attached by inspector

    public float _parameter;

    public ParameterType Type;

    /// <summary>
    /// The method that returns the value of the current parameter
    /// </summary>
    public float GetInputParameter()
    {
        string s = _inputParameter.text;
        if (s == null)
            return 0;
        
        _parameter =  (float)Convert.ToDouble(s);
        return _parameter;
    }
}
