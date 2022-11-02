using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _treePrefabs;
    public int treesCount {get; private set;} = 0;

    void Start()
    {
        Tree.OnTreeDestroyed.AddListener(RemoveTree);
        Player.OnPlayerDeath.AddListener(StopGenerating);
        StartCoroutine(Generate());
    }


    private IEnumerator Generate()
    {
        float totalTime = UnityEngine.Random.Range(0.6f, 1f);
        yield return new WaitForSeconds(totalTime);
        int treesNumber = UnityEngine.Random.Range(0, 4);
        if (totalTime < 1f && treesNumber == 3)
        {
            treesNumber--;
        }
        spawnTree(treesNumber);
        treesCount += treesNumber;
        StartCoroutine(Generate());
    }

    private void spawnTree(int number)
    {
        float deltaY = 0;
        GameObject prefab;
        for (int i = 0; i < number; i++)
        {
            int treeType = UnityEngine.Random.Range(0, _treePrefabs.Count);
            prefab = _treePrefabs[treeType];

            Instantiate(prefab, new Vector3(12 - deltaY, -2.75f, 0), Quaternion.identity);

            deltaY++;
        }
    }


    private void RemoveTree()
    {
        treesCount--;
    }

    private void StopGenerating()
    {
        StopAllCoroutines();
    }
}
