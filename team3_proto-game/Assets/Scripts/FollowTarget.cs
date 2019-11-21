using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // The character being followed
    public Transform target;
    Vector3 velocity = Vector3.zero;
    public float smoothtime = .15f;

    // Stuff needed for clamping
    private bool ymaxenabled = true;
    private float ymaxvalue = 190.3f;
    private bool yminenabled = true;
    private float yminvalue = -2.5f;
    private bool xmaxenabled = true;
    private float xmaxvalue = 193.0f;
    private bool xminenabled = true;
    private float xminvalue = 0.1f;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        if(yminenabled && ymaxenabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yminvalue, ymaxvalue);
        }
        else if (yminenabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yminvalue, target.position.y);
        }
        else if (ymaxenabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, ymaxvalue);
        }

        if (xminenabled && xmaxenabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xminvalue, xmaxvalue);
        }
        else if (xminenabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xminvalue, target.position.x);
        }
        else if (xmaxenabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xmaxvalue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothtime);
    }


}
