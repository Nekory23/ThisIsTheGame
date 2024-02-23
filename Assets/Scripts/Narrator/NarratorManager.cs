using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorManager : MonoBehaviour, IObserver
{
    public ANarrator narrator;

    public void OnEnable()
    {
    }

    public void OnDisable()
    {
    }

    public void OnNotify(PlayerAction action)
    {
        if (narrator)
        {
            narrator.OnNotify(action);
        }
    }

    public void OnNotifyString(string action)
    {
        try {
            PlayerAction enumState = (PlayerAction)Enum.Parse(typeof(PlayerAction), action);
            OnNotify(enumState);
        } catch (Exception e) {
            Debug.Log(e);
        }
    }

    public void RunAudioClip(string clipName)
    {
        if (narrator)
        {
            narrator.RunAudioClip(clipName);
        }
    }
}
