using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;

    void Start()
    {
        int IndexMusicaDeFundo = Random.Range(0, 3);
        AudioClip musicaDeFundoDoJogo = musicasDeFundo[IndexMusicaDeFundo];
        audioSourceMusicaDeFundo.clip = musicaDeFundoDoJogo;
        audioSourceMusicaDeFundo.loop = true; // rodar a musica em loop
        audioSourceMusicaDeFundo.Play();
    }
}
