using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform targetLeft;
    public Transform targetRight;
    public Transform targetBehind;
    public float distance = 5.0f;
    public float height = 0;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;

    void Update (){
        if (Input.GetKey(KeyCode.Backslash)){
            followBehind = false;
        }
        else if (Input.GetKey(KeyCode.LeftBracket)) {
            target = targetLeft;
        }
        else if (Input.GetKey(KeyCode.RightBracket)){
            target = targetRight;
        }
        else {
            followBehind = true;
            target = targetBehind;
        }

        Vector3 wantedPosition;
        if(!followBehind)
        wantedPosition = target.TransformPoint(0, height, -distance);
        else 
        wantedPosition = target.TransformPoint(0, height, distance);
        transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation){
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up); 
            transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);

        }
        else transform.LookAt (target, target.up);
    }
   
    
}
