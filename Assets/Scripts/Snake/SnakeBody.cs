using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SnakeBodyData
{
    [SerializeField] private float _partDiametr = 0.5f;
    public float PartDiametr => _partDiametr;
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
        _snakeHead = transform;
        positions.Add(_snakeHead.position);
        AddCircle();
        AddCircle();
        AddCircle();
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
    public void AddCircle()
    {
        Transform part = Instantiate(_snakeTail, positions[positions.Count - 1], Quaternion.identity, transform);
        snakePart.Add(part);
        positions.Add(part.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakePart[0].gameObject);
        snakePart.RemoveAt(0);
        positions.RemoveAt(1);
    }

}
