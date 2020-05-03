using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform playerTransform;
    public Vector2 clampX;
    public Vector2 clampY;
    public Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        myTransform.position = new Vector3(Mathf.Clamp(myTransform.position.x, clampX.x, clampX.y),
                                    Mathf.Clamp(myTransform.position.y, clampY.x, clampY.y),
                                    myTransform.position.z);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
