using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public AudioSource adSource;
    public AudioClip[] adClips;

    private bool isPlaying = true;



    IEnumerator playAudioSequentially()
{
    yield return null;

    for (int i = 0; i < adClips.Length; i++)
    {
        adSource.clip = adClips[i];

        adSource.Play();

        yield return new WaitForSeconds(adSource.clip.length);


    }
}

    void Start()
    {
        StartCoroutine(playAudioSequentially());
    }

    void Update()
    {

    }
}
