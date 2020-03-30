using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    public float smooth_factor = 0.05f;
    public float _data;
    public int Data
    {
        get
        {
            return (int)_data;
        }
        set
        {
            _data += (value - _data) * smooth_factor;

            Vector3 scale = transform.localScale;
            scale.x = _data * 0.05f;
            transform.localScale = scale;
        }
    }


    public float _data2;
    public int Data2
    {
        get
        {
            return (int)_data2;
        }
        set
        {
            _data2 += (value - _data2) * smooth_factor;

            Vector3 scale = transform.localScale;
            scale.y = _data2 * 0.05f;
            transform.localScale = scale;
        }
    }

}
