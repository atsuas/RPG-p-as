using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate() //LateUpdateに変更
    {
        transform.position = target.position;
    }
}
