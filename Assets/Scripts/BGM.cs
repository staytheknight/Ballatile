using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private List<AudioSource> audioTracks = new List<AudioSource>();
    private AudioSource introMusic;
    private AudioSource mainMusic;
    private AudioSource deathMusic;
    [SerializeField] GameObject ship;


    // Start is called before the first frame update
    void Start()
    {
        GetComponents(audioTracks);
        introMusic = audioTracks[0];
        mainMusic = audioTracks[1];
        deathMusic = audioTracks[2];
        introMusic.Play();
        //double clipLength = audioSource1.clip.samples / audioSource1.clip.frequency;
        //audioSource2.PlayScheduled(AudioSettings.dspTime + clipLength);
    
}

    // Update is called once per frame
    void Update()
    {
        if(ship != null && !introMusic.isPlaying && !mainMusic.isPlaying && !deathMusic.isPlaying)
        {
            mainMusic.Play();
        }
        else if (ship == null && !introMusic.isPlaying && !mainMusic.isPlaying && !deathMusic.isPlaying)
        {
            deathMusic.Play();
        }
    }
}
