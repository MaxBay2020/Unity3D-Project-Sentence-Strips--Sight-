using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    private AudioSource audioSource;
    public AudioClip try_again_clip, good_job_clip;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void TryAgainPlay()
    {
        audioSource.PlayOneShot(try_again_clip);
    }

    public void GoodJobPlay()
    {
        audioSource.PlayOneShot(good_job_clip);
    }



}
