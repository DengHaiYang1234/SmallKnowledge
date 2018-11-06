using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Offense owner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Offense")
        {
            //被抢走
            if (owner != null)
            {
                owner.hasFlag = false;
            }

            other.GetComponent<Offense>().hasFlag = true;
            transform.parent = other.transform;
            owner = other.GetComponent<Offense>();
        }
    }
}
