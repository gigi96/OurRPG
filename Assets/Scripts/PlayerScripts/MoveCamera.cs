using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float minimumAngle = -30f;
    [SerializeField] private float maximumAngle = 30f;

    [SerializeField] private float minZoom = 4;
    [SerializeField] private float maxZoom = 10;
    [SerializeField] private float positionView = 0;

    private Camera _camera;
    private float _rotationX = 0;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.transform.localPosition = new Vector3(0, minZoom, -(minZoom + positionView));
    }

    private void Update()
    {
        if (Input.GetAxis("Fire3") >= 0.5)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minimumAngle, maximumAngle);
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }


        float dist = Input.GetAxis("Mouse ScrollWheel");
        transform.localPosition += new Vector3(0, dist, -dist);

        if (transform.localPosition.y < minZoom)
            transform.localPosition = new Vector3(0, minZoom, -(minZoom + positionView));

        if (transform.localPosition.y > maxZoom)
            transform.localPosition = new Vector3(0, maxZoom, -(maxZoom + positionView));
    }
}
