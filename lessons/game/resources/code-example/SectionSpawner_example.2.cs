using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public River river;
    public GameObject sectionPrefab;

    public Vector3 offset;
    public int initialSize;
    public Transform sectionObserver;
    private Transform lastSection;

    void Start()
    {
        Vector3 position = Vector3.zero;
        position += offset;

        for (int i = 0; i < initialSize; i++)
        {
            GameObject section = SpawnSection(position);
            lastSection = section.transform;
            position += offset;
        }

        transform.position = position;
    }

    void Update()
    {

    }

    private GameObject SpawnSection(Vector3 position)
    {
        GameObject section = Instantiate(sectionPrefab, position, Quaternion.identity);
        river.Add(section);
        return section;
    }
}