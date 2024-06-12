using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carkManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed=30;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
