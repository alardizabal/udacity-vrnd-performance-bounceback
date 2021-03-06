﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private ParticleSystem pSystem;
    public GameManager scoreScript;

    void Start()
    {
        pSystem = GetComponentInChildren<ParticleSystem>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            scoreScript.score++;
            //Particle effect
            pSystem.Play();

            Logger.Log("Trampoline Hit");
        }

    }
}
