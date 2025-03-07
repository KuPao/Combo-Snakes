using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public AudioClip otherClip;

    [RequireComponent(typeof(AudioSource))]
    public class ExampleClass : MonoBehaviour
    {
        public AudioClip otherClip;

        IEnumerator Start()
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            audio.clip = otherClip;
            audio.Play();
        }
    }
}
