using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{    
    public PlayableAsset smallMario;
    public PlayableAsset bigMario;
    public PlayerController playerController;
    public List<TimelineAsset> fireworks;
    public ScoreManager scoreManager;

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

    /// <summary>
    ///Depending on the last digit of the timer, one of the following timeline assets is played:
    /// 1 - one firework | 3 - three fireworks | 6 - six fireworks | other - no fireworks
    /// </summary>
    /// <param name="number">last digit of the timer (when Mario jumps on the pole)</param>
    public void PlayFireworks()
    {
        int number = scoreManager.GetLastDigit();
        switch (number)
        {
            case 1:
                playableDirector.Play(fireworks[1]);
                scoreManager.Invoke("FireworkBonus", 0.7f);
                break;
            case 3:
                playableDirector.Play(fireworks[2]);
                scoreManager.Invoke("FireworkBonus", 0.7f);
                break;
            case 6:
                playableDirector.Play(fireworks[3]);
                scoreManager.Invoke("FireworkBonus", 0.7f);
                break;
            default:
                playableDirector.Play(fireworks[0]);
                break;
        }
    }
}
