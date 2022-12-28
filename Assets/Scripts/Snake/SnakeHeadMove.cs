using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnakeHeadMoveData
{
    [SerializeField] private float _speedX = 0.4f;
    [SerializeField] private float _speedZ = 0.4f;
    public float SpeedX { get => _speedX; set => _speedX = value; }
    public float SpeedZ { get => _speedZ; set => _speedZ = value; }

}
public class SnakeHeadMove : MonoBehaviour
{
    private SnakeHeadMoveData Data => GeneralSettings.Instance.SnakeHeadMoveData;
    private Transform _snakeHead;
    private Rigidbody rb;
    private Vector3 _mousePosition;
    private Vector3 _directione;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _snakeHead = transform;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            _directione = (hit.point - _snakeHead.position).normalized * Data.SpeedX;
        }
        else
        {
            _directione = Vector3.zero;
        }
        _directione.z = Data.SpeedZ;

    }
    private void FixedUpdate()
    {
        rb.velocity = _directione;
    }
}
