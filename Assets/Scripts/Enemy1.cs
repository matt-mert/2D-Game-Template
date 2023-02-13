using System.Security.Cryptography;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5000)]
    private float _thrust = 1000f;
    [SerializeField]
    private GameObject _target = null;
    [SerializeField]
    private Transform _pointer = null;
    [SerializeField]
    [Range(-10, 10)]
    private float _zAxisP, _zAxisI, _zAxisD;

    private Rigidbody2D enemyRb;
    private PID _zAxisPIDController;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        _zAxisPIDController = new PID(_zAxisP, _zAxisI, _zAxisD);
    }

    private void Update()
    {
        _zAxisPIDController.Kp = _zAxisP;
        _zAxisPIDController.Ki = _zAxisI;
        _zAxisPIDController.Kd = _zAxisD;
    }

    private void FixedUpdate()
    {
        Vector2 targetDirection = transform.position - _target.transform.position;
        Vector2 frontDirection = transform.position - _pointer.position;
        float angle = Vector2.SignedAngle(frontDirection, targetDirection);
        
        //float zAngleError = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, angle);
        float zTorqueCorrection = _zAxisPIDController.GetOutput(angle, Time.fixedDeltaTime);
        
        enemyRb.AddTorque(zTorqueCorrection);
        enemyRb.velocity = frontDirection.normalized * _thrust * Time.fixedDeltaTime;
    }
}
