using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingSpeed;

    private Vector3 direction;
    private Vector3 overshoot;

    private void Update()
    {
        if(direction != Vector3.zero)
        {
            overshoot = direction;
            transform.eulerAngles += speed * Time.deltaTime * new Vector3(direction.y, -direction.x);
        }
        else
        {
            overshoot = Vector3.Lerp(overshoot, Vector3.zero, Time.deltaTime);
            transform.eulerAngles += stoppingSpeed * Time.deltaTime * new Vector3(overshoot.y, -overshoot.x);
        }
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}