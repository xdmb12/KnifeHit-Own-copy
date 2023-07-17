using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieManager : MonoBehaviour
{
    [Header("Pie")]
    public float speed;

    [Header("Apples")]
    [SerializeField] private GameObject[] apples;
    [SerializeField] private float spawnChance = 0.5f;
    
    void Start()
    {
        RandomAppleSpawner();
    }
    
    void Update()
    {
        float newRotation = transform.rotation.eulerAngles.y + speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newRotation, transform.rotation.eulerAngles.z);
    }
    
    private void RandomAppleSpawner()
    {
        foreach (var i in apples)
        {
            if (spawnChance >= Random.Range(0f, 1f))
            {
                i.SetActive(true);
            }
        }
    }
}
