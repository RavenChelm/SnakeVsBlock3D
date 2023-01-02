using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SnakeBodyData
{
    [SerializeField] private float _partDiametr = 0.5f;
    public float PartDiametr => _partDiametr;
    [SerializeField] private int _startPart = 4;
    public int StartBlock { get => _startPart; set => _startPart = value; }
    private int _currentPart = 1;
    public int CurrentPart { get => _currentPart; set => _currentPart = value; }
}
public class SnakeBody : MonoBehaviour
{
    private Transform _snakeHead;
    [SerializeField] private Transform _snakeTail;
    public Transform SnakeTail => _snakeTail;
    public SnakeBodyData Data => GeneralSettings.Instance.SnakeBodyData;
    private List<Transform> snakePart = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        Data.CurrentPart = 1;
        _snakeHead = transform;
        positions.Add(_snakeHead.position);
        AddPart(Data.StartBlock - 1);

    }
    private void Update()
    {
        float distance = ((Vector3)_snakeHead.position - positions[0]).magnitude;

        if (distance > Data.PartDiametr)
        {
            // Направление от старого положения головы, к новому
            Vector3 direction = ((Vector3)_snakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * Data.PartDiametr);
            positions.RemoveAt(positions.Count - 1);

            distance -= Data.PartDiametr;
        }

        for (int i = 0; i < snakePart.Count; i++)
        {
            snakePart[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / Data.PartDiametr);
        }
    }
    public void AddPart(int value)
    {
        Data.CurrentPart += value;
        for (int i = 0; i < value; i++)
        {
            Transform part = Instantiate(_snakeTail, positions[positions.Count - 1], Quaternion.identity, transform);
            snakePart.Add(part);
            positions.Add(part.position);
        }
    }

    public void RemovePart(int value)
    {
        Debug.Log(value);
        Data.CurrentPart += value;
        if (Data.CurrentPart != 0)
        {
            Destroy(snakePart[snakePart.Count - 1].gameObject);
            snakePart.RemoveAt(snakePart.Count - 1);
            positions.RemoveAt(positions.Count - 1);
        }

    }

}
