using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _loseMenu;
    private GameData Data => GeneralSettings.Instance.GameData;
    private bool onGame = true;
    private void Awake()
    {

        Pause();
    }
    public void MenuOn(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void MenuOff(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void GameOverMenu()
    {
        _loseMenu.SetActive(true);
        Pause();
    }
    public void GameVictoryMenu()
    {
        _victoryMenu.SetActive(true);
        Pause();
    }
    public void Pause()
    {
        if (onGame)
        {
            Time.timeScale = 0;
            onGame = false;
        }
        else
        {
            Time.timeScale = 1;
            onGame = true;
        }
    }
    public void NextLevel()
    {
        Data.CurrentLevel++;
        Debug.Log(Data.CurrentLevel);
        GameController.LoadScene(Data.CurrentLevel);
    }
    public void RestartLevel()
    {
        GameController.LoadScene(Data.CurrentLevel);
    }
}