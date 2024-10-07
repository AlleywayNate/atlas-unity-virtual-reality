using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
   {
       public static AudioManager Instance;

       public AudioClip startSelectClip;
       public AudioClip selectDurationClip;
       public AudioClip finishSelectClip;
       public AudioClip gazeHintClip;

       private AudioSource audioSource;

       void Awake()
       {
           if (Instance == null)
           {
               Instance = this;
               DontDestroyOnLoad(gameObject);
           }
           else
           {
               Destroy(gameObject);
           }

           audioSource = gameObject.AddComponent<AudioSource>();
       }

       public void PlayStartSelect()
       {
           audioSource.PlayOneShot(startSelectClip);
       }

       public void PlaySelectDuration()
       {
           audioSource.PlayOneShot(selectDurationClip);
       }

       public void PlayFinishSelect()
       {
           audioSource.PlayOneShot(finishSelectClip);
       }

       public void PlayGazeHint()
       {
           audioSource.PlayOneShot(gazeHintClip);
       }
   }