using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSound : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hmmmm");
            audioSource.enabled = true;
            if (!audioSource.isPlaying)
            {
                audioSource.clip = sound;
                audioSource.Play();

            }
            else
            {
                audioSource.enabled = false;

            }

        }
    }}