using UnityEngine;
using System.Collections;

using System.Collections.Generic;      
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public static MapController map;
    public static Player player;
    public static Enemy enemy;
    public static bool started = false;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        MainMenu();
    }

    private void OnLevelWasLoaded(int level)
    {

    }

    public static void Play(string playerName)
    {
        player = new Player(playerName, 3);
        SceneManager.LoadScene(3);
    }

    public static void StartGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void Battle(Enemy target)
    {
        enemy = target;
        SceneManager.LoadScene(2);
    }

    public static void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}