using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense : MonoBehaviour
{
    public bool hasFlag = false;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Defence")
        {
            if (hasFlag)
            {
                hasFlag = false;
                CTFGameManager.Instance.DropFlag();
                if (transform.childCount > 0)
                {
                    var flag = transform.GetChild(0);
                    flag.GetComponent<Flag>().owner = null;
                    flag.parent = null;
                }
            }

            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}
