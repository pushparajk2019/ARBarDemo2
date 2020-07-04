using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BarBehaviour : MonoBehaviour
{
    const float SPEED = 3f;
    Vector3 desiredScale;
    // Start is called before the first frame update
    void Start()
    {
        desiredScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    public void SetScale(float y)
    {
        desiredScale.y = y;

    }

    public void Reset()
    {
        desiredScale.y = 0;
        transform.localScale = desiredScale;
    }


}
