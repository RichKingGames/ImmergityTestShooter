using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The class that controls all input fields and play button.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private List<ParameterField> _parameterFields = null; // attached by inspector

    public void GoToLevel() // invokes by play button in main menu
    {

        GameProperties.SetProperties(GetPlayerHealth(), GetPlayerDamage(), 
            GetMobsHealth(), GetMobsDamage(), GetSpawnTime());
        SceneManager.LoadScene("Level0");
    }
    private float GetPlayerHealth()
    {
        return FindFieldByType(ParameterType.PlayerHealth).GetInputParameter();
    }
    private float GetPlayerDamage()
    {
        return FindFieldByType(ParameterType.PlayerDamage).GetInputParameter();
    }
    private float GetMobsHealth()
    {
        return FindFieldByType(ParameterType.MobsHealth).GetInputParameter();
    }
    private float GetMobsDamage()
    {
        return FindFieldByType(ParameterType.MobsDamage).GetInputParameter();
    }
    private float GetSpawnTime()
    {
        return FindFieldByType(ParameterType.SpawnTime).GetInputParameter();
    }
    private ParameterField FindFieldByType(ParameterType type)
    {
        for (int i = 0; i < _parameterFields.Count; i++)
        {
            if (type == _parameterFields[i].Type)
            {
                return _parameterFields[i];
            }
        }
        return null;
    }
}
