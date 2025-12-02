using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraFollow : MonoBehaviour
{
    public float smoothing;
    public Transform target;
    private Vector3 targetPos;
    public Vector2 minPos;
    public Vector2 maxPos;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position != transform.position)
            {
                targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
    public void SetCamLimit(Vector2 min, Vector2 max)
    {
        minPos = min;
        maxPos = max;
    }
}
