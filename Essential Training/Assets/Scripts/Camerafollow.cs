using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject target;
    private Transform _t;
    // Start is called before the first frame update
    void Start()
    {
        _t = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(_t.position.x,_t.position.y,transform.position.z);
    }
}
