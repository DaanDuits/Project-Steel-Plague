using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public SerialPort stream = new SerialPort();

    [SerializeField] private float cameraDistance;
    [SerializeField] private float zoomDistance;

    [SerializeField] private float speed;
    [SerializeField] private float stoppingSpeed;

    private Vector3 direction;
    private Vector3 overshoot;

    private bool inZoom;

    private void Start()
    {
        if(SerialPort.GetPortNames().Length > 0)
        {
            foreach(string port in SerialPort.GetPortNames())
            {
                stream.PortName = port;
                stream.BaudRate = 9600;

                stream.Open();

                if(stream.ReadLine().Split(',').Length == 2)
                {
                    break;
                }
                else
                {
                    stream.Close();
                }
            }
        }
        else
        {
            Debug.Log("Controller Not Found");
        }

        Camera.main.transform.localPosition = new Vector3(0, 0, cameraDistance);
    }

    private void Update()
    {
        if(stream.IsOpen && stream.BytesToRead > 0)
        {
            string[] data = stream.ReadLine().Split(',');

            if(data.Length == 2)
            {
                try
                {
                    float x = float.Parse(data[0], CultureInfo.InvariantCulture);
                    float y = float.Parse(data[1], CultureInfo.InvariantCulture);

                    direction = new Vector3(x, y);
                }
                catch(FormatException)
                {
                    Debug.Log("Parsing Failed");
                }
            }
        }

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

        Camera.main.transform.localPosition = inZoom ? new Vector3(0, 0, zoomDistance) : new Vector3(0, 0, cameraDistance);
    }
}