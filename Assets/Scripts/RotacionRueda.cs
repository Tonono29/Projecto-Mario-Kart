using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionRueda : MonoBehaviour
{
    private void Start()
    {
        ruedacollider.transform.rotation = this.transform.rotation;
    }
    [SerializeField] private WheelCollider ruedacollider;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        this.transform.rotation = ruedacollider.transform.rotation;
    }
}
