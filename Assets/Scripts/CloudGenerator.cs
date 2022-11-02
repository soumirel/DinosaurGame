using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private float _deltaSetting;

    [SerializeField] private GameObject _cloudPrefab;

    [SerializeField] private List<Sprite> _spriteList;

    private SpriteRenderer _spriteRenderer;

    private float _yPosition;


    void Start()
    {
        Player.OnPlayerDeath.AddListener(StopGenerating);
        
        StartCoroutine(GenerateCloud());
    }


    private IEnumerator GenerateCloud()
    {
        yield return new WaitForSeconds(_deltaSetting);

        _yPosition = Random.Range(-2f, 4.5f);
        GameObject cloud = Instantiate(_cloudPrefab, new Vector3(13, _yPosition, 0), Quaternion.identity);

        _spriteRenderer = cloud.GetComponent<SpriteRenderer>();
        SetRandomCloudSprite(_spriteRenderer);

        StartCoroutine(GenerateCloud());
    }
    private void StopGenerating()
    {
        StopAllCoroutines();
    }

    private void SetRandomCloudSprite(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer.sprite = _spriteList[Random.Range(0, _spriteList.Count)];
    }
}
