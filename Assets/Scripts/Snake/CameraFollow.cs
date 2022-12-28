using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraFollowData
{
    [SerializeField] private float _lerpValue;
    [SerializeField] private float _cameraOffset = -2;
    public float LerpValue { get => _lerpValue; set => _lerpValue = value; }
    public float CameraOffset { get => _cameraOffset; set => _cameraOffset = value; }
}
public class CameraFollow : MonoBehaviour
{
    private CameraFollowData Data => GeneralSettings.Instance.CameraFollowData;
    [SerializeField] private Transform _target;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }
    private void FixedUpdate()
    {
        var temp = new Vector3(_target.position.x, _transform.position.y, _target.position.z + Data.CameraOffset);
        _transform.position = Vector3.Lerp(_transform.position, temp, Data.LerpValue * Time.fixedDeltaTime);
    }
}
