using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject target;
    Vector3 positionOffset = new Vector3(0, 3.4f, -2.4f);
    Quaternion rotationOffset = Quaternion.Euler(37, 0, 0);

    [SerializeField] private string targetTag;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        transform.SetParent(target.transform.root);
        transform.localPosition = positionOffset;
        transform.localRotation = rotationOffset;
    }

}
