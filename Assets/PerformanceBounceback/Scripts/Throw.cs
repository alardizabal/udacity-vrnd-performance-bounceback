﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    public float throwForce = 2f;
    private Rigidbody rigidBody;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            rigidBody = col.GetComponent<Rigidbody>();
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Logger.Log("You have released the trigger");

                //Multi Throwing
                col.transform.SetParent(null);
                rigidBody.isKinematic = false;
                rigidBody.velocity = device.velocity * throwForce;
                rigidBody.angularVelocity = device.angularVelocity;
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Logger.Log("You are touching down the trigger on an object");
                rigidBody.isKinematic = true;
                col.transform.SetParent(gameObject.transform);

                device.TriggerHapticPulse(2000);
            }
        }
    }
}
