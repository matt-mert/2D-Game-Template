using System;

[Serializable]
public class PID
{
    private float _p, _i, _d;
    private float _kp, _ki, _kd;
    private float _prevError;

    public float Kp { get { return _kp; } set { _kp = value; } }
    public float Ki { get { return _ki; } set { _ki = value; } }
    public float Kd { get { return _kd; } set { _kd = value; } }

    public PID(float p, float i, float d)
    {
        _kp = p;
        _ki = i;
        _kd = d;
    }

    public float GetOutput(float currentError, float deltaTime)
    {
        _p = currentError;
        _i += _p * deltaTime;
        _d = (_p - _prevError) / deltaTime;
        _prevError = currentError;

        return _p * Kp + _i * Ki + _d * Kd;
    }
}
