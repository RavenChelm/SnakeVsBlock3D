using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    [SerializeField] private int _levelCount = 3;
    public int LevelCount { get => _levelCount; }
    [SerializeField] private int _currentLevel;
    public int CurrentLevel
    {
        get => _currentLevel;
        set { _currentLevel = value >= _levelCount ? 0 : value; }
    }
    private bool _sound = true;
    public bool Sound { get => _sound; set => _sound = value; }
}

public static class GameController
{
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index.ToString());
    }
}
































// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using UnityEngine.UI;
// public class GameData
// {

// }
// public class Game : MonoBehaviour
// {
//     [SerializeField] private List<Scene> levels;
//     public enum State
//     {
//         Pause,
//         Playing,
//         Victory,
//         Lose,
//     }
//     public State CurrrentState { get; private set; }
//     public int CurrentLevel = 0;
//     private void Awake()
//     {
//         toAnotherState(State.Pause);
//     }
//     private void toPlay()
//     {
//         CurrrentState = State.Playing;
//         Time.timeScale = 1;
//     }
//     private void toAnotherState(State state)
//     {
//         CurrrentState = state;
//         Time.timeScale = 0;
//     }
//     private void CheckState()
//     {
//         switch (CurrrentState)
//         {
//             case State.Victory:

//                 break;
//             case State.Lose:

//                 break;
//             default:

//                 break;
//         }
//     }
// }