using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mar : MonoBehaviour
{
    [SerializeField] private float angleDegree;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angularvelocity;



    void Update()
    {
        angleDegree -= angularvelocity * Time.deltaTime;
        Polar2Cartesian(angleDegree, radius).Draw(Color.red);

    }

    MiVector Polar2Cartesian(float angle, float rad)
    {
        float x = Mathf.Cos(angleDegree * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleDegree * Mathf.Deg2Rad);
        MiVector unitdir = new MiVector(x * radius, y * radius);
        return unitdir;
    }
}
