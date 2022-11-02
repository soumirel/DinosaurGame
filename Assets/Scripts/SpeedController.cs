using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedController : MonoBehaviour
{
    [SerializeField] private float speedSettings;
    [SerializeField] private float increaseSetting;
    public static float mainSpeed { get; private set; }

    public static UnityEvent<float> OnSpeedIncreased = new UnityEvent<float>();
    void Start()
    {
        RestartManager.OnGamePaused.AddListener(KurnSpeed);
        mainSpeed = speedSettings;
        StartCoroutine(UpdateSpeed());
    }

    void Update()
    {
        
    }

    private IEnumerator UpdateSpeed()
    {
        yield return new WaitForSeconds(10);
        mainSpeed += increaseSetting;
        StartCoroutine(UpdateSpeed());
    }

    private void KurnSpeed()
    {
        StopAllCoroutines();
        mainSpeed = 0;
    }
}
