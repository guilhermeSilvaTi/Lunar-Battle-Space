using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    [SerializeField]
    GameObject newGroupCall;

    [SerializeField]
    GameObject currentGroup;

    [SerializeField]
    AudioSource sound;

    public void CallGroup()
    {
        currentGroup.SetActive(false);
        sound.Play();
        newGroupCall.SetActive(true);
    }



}
