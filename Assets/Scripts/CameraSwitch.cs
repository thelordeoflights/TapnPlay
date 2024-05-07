using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitch : MonoBehaviour
{

    [SerializeField] List<PlayableDirector> playableDirectors;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;

    public void BusStop()
    {
        Button1.SetActive(false);
        Button2.SetActive(true);
        playableDirectors[0].Play();
    }
    public void TicketBooth()
    {
        Button1.SetActive(true);
        Button2.SetActive(false);
        playableDirectors[1].Play();
    }
}
