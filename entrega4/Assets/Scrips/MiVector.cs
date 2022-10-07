using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct MiVector
{
    public float x;
    public float y;
    public float magnitude => Mathf.Sqrt(x * x + y * y);

    public MiVector normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001f)
            {
                return new MiVector(0, 0);
            }
            return new MiVector(x / distance, y / distance);
        }
    }
    public MiVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"[{x},{y}]";
    }
    public static implicit operator Vector3(MiVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), this, color, 0);

    }
    public void Draw2(MiVector origin, Color color)
    {
        Debug.DrawLine(origin, this + origin, color, 0);

    }
    public MiVector Lerp(MiVector miVector, float t)
    {
        return this + (miVector - this) * t;
    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }
    }
    public static MiVector operator +(MiVector v1, MiVector v2)
    {
        return new MiVector(v1.x + v2.x, v1.y + v2.y);

    }
    public static MiVector operator -(MiVector v1, MiVector v2)
    {
        return new MiVector(v1.x - v2.x, v1.y - v2.y);

    }
    public static MiVector operator *(MiVector v1, float n)
    {
        return new MiVector(v1.x * n, v1.y * n);

    }
    public static implicit operator MiVector(Vector3 a)
    {
        return new MiVector(a.x, a.y);
    }


}