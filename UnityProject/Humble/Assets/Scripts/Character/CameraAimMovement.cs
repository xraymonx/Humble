using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAimMovement : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed;
    private Vector3 offset;

    private void Start(){
        offset = target.transform.position - transform.position;
    }

    private void LateUpdate(){
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        
        target.transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.Rotate(-vertical,0,0);
    
        //float desiredAngle = target.transform.eulerAngles.y;
        //Quaternion rotation = Quaternion.Euler(Vertical, desiredAngle, 0);
        //transform.position = target.transform.position - (rotation * offset);
 
        //transform.LookAt(target.transform);

    }
}
