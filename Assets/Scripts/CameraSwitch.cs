using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitch : MonoBehaviour
{

    [SerializeField] List<PlayableDirector> playableDirectors;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameManager gameManager;


    public void BusStop()
    {
        Button1.SetActive(false);
        Button2.SetActive(true);
        playableDirectors[0].Play();
        playableDirectors[0].played += OnTimeLineStart;
    }
    public void TicketBooth()
    {
        Button1.SetActive(true);
        Button2.SetActive(false);
        playableDirectors[1].Play();
        playableDirectors[1].stopped += OnTimelineEnd;
    }
    void OnTimeLineStart(PlayableDirector playableDirector)
    {
        gameManager.araButton.SetActive(false);
        gameManager.kioskButton.SetActive(false);

    }

    void OnTimelineEnd(PlayableDirector playableDirector)
    {
        gameManager.araButton.SetActive(true);
        gameManager.kioskButton.SetActive(true);
    }
}
