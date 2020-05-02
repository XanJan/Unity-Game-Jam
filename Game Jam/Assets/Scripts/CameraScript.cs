using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 targetOffset;
    public float cameraSpeed;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    public void SetTarget(Transform aTransform)
    {
        followTarget = aTransform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(followTarget != null)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, followTarget.position + targetOffset, cameraSpeed * Time.fixedDeltaTime);
        }
    }
}
