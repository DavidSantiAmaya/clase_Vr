using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Empujar : MonoBehaviour
{
    public float Empuje = 5.0f;
    private float obtenerMasa;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody objeto = hit.collider.attachedRigidbody;

        if (objeto == null || objeto.isKinematic) {

            return;

        }

        if ( hit.moveDirection.y < -0.3)
        {
            return;
        }
        obtenerMasa = objeto.mass;

        UnityEngine.Vector3 empujeDir = new UnityEngine.Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        objeto.linearVelocity = empujeDir * Empuje/obtenerMasa;


    }
}
