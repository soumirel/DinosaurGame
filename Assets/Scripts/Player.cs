using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpTime;

    [SerializeField] private Sprite _spriteStep1;
    [SerializeField] private Sprite _spriteStep2;

    private bool isJumping;

    private SpriteRenderer _spriteRenderer;

    public static UnityEvent OnPlayerDeath = new UnityEvent();

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeStepSprite());
    }

    private void Update()
    {
       if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Mouse0)) && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        var startPos = transform.position;
        float time = 0;
        float totalTime = _jumpTime * (1 / SpeedController.mainSpeed);
        while (time < totalTime)
        {
            time += Time.deltaTime;
            Vector3 pos = new Vector3(startPos.x, startPos.y + _jumpCurve.Evaluate(time/totalTime) * 3f, startPos.z);
            transform.position = pos;
            yield return null;
        }
        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerDeath.Invoke();
        Destroy(this.gameObject);
    }

    private IEnumerator ChangeStepSprite()
    {
        yield return new WaitForSeconds(0.125f);
        if (_spriteRenderer.sprite == _spriteStep2)
        {
            _spriteRenderer.sprite = _spriteStep1;
        }
        else
        {
            _spriteRenderer.sprite = _spriteStep2;
        }
        StartCoroutine(ChangeStepSprite());
    }
}
