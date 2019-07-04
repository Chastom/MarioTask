using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{    
    public PlayableAsset smallMario;
    public PlayableAsset bigMario;
    public PlayerController playerController;

    private PlayableDirector playableDirector;

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayCutscene()
    {
        //One of the two payableAssets is played, depending on current Mario state
        playableDirector.playableAsset = playerController.poweredUp ? bigMario : smallMario;
        playableDirector.Play();
    }
}
