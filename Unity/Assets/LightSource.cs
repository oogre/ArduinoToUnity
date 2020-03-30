using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public int _lightIntensity;
    public int lightIntensity {
        get
        {
            return _lightIntensity;
        }
        set
        {
            _lightIntensity = value;
        }
    }

    public void Update()
    {
        print( this.GetComponent<OscJack.OscEventReceiver>().intData ) ;
    }
}
