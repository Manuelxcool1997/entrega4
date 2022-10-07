using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polar : MonoBehaviour
{

    [SerializeField] float Acceleracion;
    [SerializeField] float angular;
    [SerializeField] float radial;
    [SerializeField] MiVector polaridad;


    void Start()
    {

    }

    void Update()
    {

        polaridad.x += Time.deltaTime * radial;


        polaridad.y += Time.deltaTime * angular;

   
        MiVector cartesianPoint = Polarvector(polaridad);



        cartesianPoint.Draw(Color.cyan);

       
        transform.position = cartesianPoint;

      
        CheckBounds();


    }
    MiVector Polarvector(MiVector polar)
    {
        float x = Mathf.Cos(polar.y * Mathf.Deg2Rad) * polar.x;
        float y = Mathf.Sin(polar.y * Mathf.Deg2Rad) * polar.x;
        MiVector unitdir = new MiVector(x, y);
        return unitdir;
    }
    void CheckBounds()
    {
        if (Mathf.Abs(polaridad.x) >= 5)
        {
            polaridad.x = Mathf.Sign(polaridad.x) * 5;

            if (Mathf.Abs(Acceleracion) > 0)
            {
                Acceleracion = -Acceleracion;
                radial *= -1;
            }
            else 
            {
                radial = -radial; 
            }

        }

    }
}
