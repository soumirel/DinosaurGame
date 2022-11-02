using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour
{
    [SerializeField] private float _speedSetting;

    private Transform _backTranform;
    private float _backSize;
    private float _backPosition;

    void Start()
    {
        _backTranform = GetComponent<Transform>();
        _backSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        _backPosition -= convertMainToOwnSpeed() * Time.deltaTime;
        _backPosition = Mathf.Repeat(_backPosition, _backSize);
        _backTranform.position = new Vector3(_backPosition, 1, 0);
    }

    private float convertMainToOwnSpeed()
    {
        return _speedSetting * SpeedController.mainSpeed;
    }
}
