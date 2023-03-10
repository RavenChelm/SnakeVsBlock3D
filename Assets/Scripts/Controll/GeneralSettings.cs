using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GeneralSettings", fileName = "GeneralSettings")]
public class GeneralSettings : ScriptableObject
{
    //LOAD
    private static GeneralSettings _instace;
    public static GeneralSettings Instance => _instace == null ? LoadData() : _instace;
    //DATA
    [SerializeField] private SnakeData _snakeData;
    public SnakeData SnakeData => _snakeData;
    [SerializeField] private SnakeHeadMoveData _snakeHeadMoveData;
    public SnakeHeadMoveData SnakeHeadMoveData => _snakeHeadMoveData;
    [SerializeField] private SnakeBodyData _snakeBodyData;
    public SnakeBodyData SnakeBodyData => _snakeBodyData;
    [SerializeField] private CameraFollowData _cameraFollowData;
    public CameraFollowData CameraFollowData => _cameraFollowData;
    [SerializeField] private BlockFoodData _blockFoodData;
    public BlockFoodData BlockFoodData => _blockFoodData;
    [SerializeField] private BlockHorizontalData _blockHorizontalData;
    public BlockHorizontalData BlockHorizontalData => _blockHorizontalData;
    [SerializeField] private GameData _gameData;
    public GameData GameData => _gameData;
    [SerializeField] private UIData _uiData;
    public UIData UIData => _uiData;

    private static GeneralSettings LoadData()
    {
        return _instace = Resources.Load<GeneralSettings>("GeneralSettings");
    }
}