using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public River river;
    public GameObject sectionPrefab;

    void Start()
    {

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