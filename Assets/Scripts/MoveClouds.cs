using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    [SerializeField] private float _speedSetting;

    void Update()
    {
        if (transform.position.x < -13)
        {
            Destroy(this.gameObject);
        }
        transform.position -= new Vector3(convertMainToOwnSpeed(), 0, 0) * Time.deltaTime;
    }

    private float convertMainToOwnSpeed()
    {
        return _speedSetting * SpeedController.mainSpeed;
    }
}
