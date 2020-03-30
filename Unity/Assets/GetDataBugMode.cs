using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDataBugMode : MonoBehaviour
{
    public OscJack.OscEventReceiver input;
    public int data;

    public void Update()
    {
        data = input.intData;
    }
}
