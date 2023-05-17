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

    [SerializeField] private float zoomDistance;
    private float defaultDistance;

    private bool inZoom;

    private void Start()
    {
        defaultDistance = Camera.main.transform.position.z;
    }

    private void Update()
    {
        if(direction != Vector3.zero)
        {
            overshoot = direction;
            transform.localEulerAngles += speed * Time.deltaTime * new Vector3(direction.y, -direction.x);
        }
        else
        {
            overshoot = Vector3.Lerp(overshoot, Vector3.zero, Time.deltaTime);
            transform.localEulerAngles += stoppingSpeed * Time.deltaTime * new Vector3(overshoot.y, -overshoot.x);
        }
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    public void OnZoom(InputValue value)
    {
        inZoom = value.Get<float>() > 0 || (value.Get<float>() >= 0 && inZoom);

        Camera.main.transform.localPosition = inZoom ? new Vector3(0, 0, zoomDistance) : new Vector3(0, 0, defaultDistance);
    }
}