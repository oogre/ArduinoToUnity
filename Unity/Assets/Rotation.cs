using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int _data;
    public int Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            Vector3 angles = transform.localEulerAngles;
            angles.x = _data;
            angles.y = _data;
            transform.localEulerAngles = angles;
        }
    }

}
