using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    //If you do not use center of mass the wheels base it off of the colliders
    //By using center of mass you can control where it is.
    public Transform t_CenterOfMass;

    //The maximum amount of power put out by each wheel.
    public float maxTorque = 500f;

    //The max distance a wheel can turn.
    public float maxSteerAngle = 45f;

    //Each wheel needs its own mesh
    public Transform[] wheelMesh = new Transform[4];

    //The physics of the wheels, max 20 axels.
    //WheelCollider[4] 4 is how many wheels we have.
    public WheelCollider[] wheelCollider = new WheelCollider[4];

    //Ridged body accessor.
    private Rigidbody r_Ridgedbody;

    public void Start()
    {
        // This sets where the center of mass is, if you look r_Ridgedbody."centerOfMass" is a function of ridged body.
        r_Ridgedbody = GetComponent<Rigidbody>();
        r_Ridgedbody.centerOfMass = t_CenterOfMass.localPosition;
    }

    public void Update()
    {
        //Sets the wheel meshs to match the rotation of the physics WheelCollider.
        UpdateMeshPosition();
    }

    public void FixedUpdate()
    {
        //Turn the wheels to a set max, with an input.
        float steer = Input.GetAxis("Horizontal") * maxSteerAngle;
        //Move forward or backwards based on the maxTorque, with an input.
        float torque = Input.GetAxis("Vertical") * maxTorque;

        //Sets which wheels turn, this is the two front wheels.
        wheelCollider[0].steerAngle = steer;
        wheelCollider[1].steerAngle = steer;

        //Sets which wheels move forward or backwards.
        for (int i = 0; i < 4; i++)
        {
            wheelCollider[i].motorTorque = torque;
        }
    }

    //Sets each wheel to move with the physics WheelColliders.
    public void UpdateMeshPosition()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;

            //Gets the current position of the physics WheelColliders.
            wheelCollider[i].GetWorldPose(out pos, out quat);

            ///Sets the mesh to match the position and rotation of the physics WheelColliders.
            wheelMesh[i].position = pos;
            wheelMesh[i].rotation = quat;
        }
    }
}