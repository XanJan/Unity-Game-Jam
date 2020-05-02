using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 targetOffset;
    public float cameraSpeed;
    public Vector2 clampX;
    public Vector2 clampY;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        myTransform.position = new Vector3 (Mathf.Clamp(myTransform.position.x, clampX.x, clampX.y), 
                                            Mathf.Clamp(myTransform.position.y, clampY.x, clampY.y),
                                            myTransform.position.z);
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
