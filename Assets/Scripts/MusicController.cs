using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("Volume") / 10;
    }
}
