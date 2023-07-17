using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{

    [SerializeField] private float launchForce;
    [SerializeField] private GameObject knifePrefab;

    private GameObject activeKnife;
    void Start()
    {
        activeKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity, transform);
    }
    
    void Update()
    {
        // if(Input.touches.Length > 0)
        // {
        //     Touch touch = Input.touches[0];
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         LaunchKnife();
        //         StartCoroutine(WaitForTheNextKnife());
        //     }
        // }

        if (Input.GetMouseButtonDown(0))
        {
            LaunchKnife();
            StartCoroutine(WaitForTheNextKnife());
        }
    }

    private void LaunchKnife()
    {
        activeKnife.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }

    IEnumerator WaitForTheNextKnife()
    {
        yield return new WaitForSeconds(0.4f);
        activeKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity, transform);
    }
}
