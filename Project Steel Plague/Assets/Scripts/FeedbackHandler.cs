using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackHandler : MonoBehaviour
{
    [SerializeField] private float speed;
    private float t;

    private void OnEnable()
    {
        t = 1;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.up;
        t -= Time.deltaTime;

        if(t <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}