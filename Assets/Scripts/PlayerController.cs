using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float moveSensitivity = 3f;
    private PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final movement Vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Applying movement
        motor.Move(_velocity);

        //Rotation 3d Vectors (Turning around)

        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * moveSensitivity;

        //Apply player rotation
        motor.Rotate(_rotation);

        //Camera Rotation 3d Vectors (Turning around)

        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * moveSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);

    }
}
