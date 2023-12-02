using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private Transform _fieldTR;
    [SerializeField] private Pose _targetPos;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        transform.position = _fieldTR.position;
        StartCoroutine(LateStart());
    }
    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        _mainCamera.transform.position = _targetPos.position;
        _mainCamera.transform.rotation = _targetPos.rotation;
    }
}
