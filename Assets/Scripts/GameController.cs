using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// The class that sets the parameters of the game and ends the game.
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerController Player;
    public SpawnController Spawner;

    [SerializeField] private GameObject GameEndPanel = null; 
    [SerializeField] private Text GameEndText = null; //attached by inspector
    [SerializeField] private Button ToMainMenu = null;

    void Start()
    {
        instance = this;
        SetProperties();
    }

    /// <summary>
    /// The method that sets the parameters of the game.
    /// </summary>
    private void SetProperties()
    {
        Player.SetPlayerProperties(GameProperties.PlayerHealth, GameProperties.PlayerDamage);
        Spawner.SetSpawnProperties(GameProperties.SpawnTime);
    }

    //Invokes by "To main menu" button in "Level0" Scene.
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// The method that ends the game.
    /// </summary>
    public void GameEnd(string s)
    {
        //Activate Game End Panel
        GameEndPanel.SetActive(true);
        GameEndText.text = s;
        ToMainMenu.gameObject.SetActive(true);

        //Stop spawning mobs and destroy player
        Spawner.StopSpawning();
        Destroy(Player.gameObject);
    }
}
