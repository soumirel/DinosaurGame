using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField] private float _speedSetting;

    public static UnityEvent OnTreeDestroyed = new UnityEvent();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -12)
        {
            OnTreeDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        transform.position -= new Vector3(convertMainToOwnSpeed(), 0, 0) * Time.deltaTime;
    }

    private float convertMainToOwnSpeed()
    {
        return _speedSetting * SpeedController.mainSpeed;
    }
}
