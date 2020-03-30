using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDataNormalMode : MonoBehaviour
{
    public int _data;
    public int data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }
}
