using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapDataSwapUI : MonoBehaviour
{
    public GameObject TownOfBeginings;
    public GameObject DungonF1;
    public GameObject BossF1;
    public GameObject ChatPlace;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();


        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Dungon1")
        {
            DungonF1.SetActive(true);
            ChatPlace.SetActive(false);
            BossF1.SetActive(false);
            TownOfBeginings.SetActive(false);
        }
        else if (sceneName == "TownOfBeginnings")
        {
            TownOfBeginings.SetActive(true);
            ChatPlace.SetActive(false);
            DungonF1.SetActive(false);
            BossF1.SetActive(false);
        }
        else if (sceneName == "Floors")
        {
            BossF1.SetActive(true);
            ChatPlace.SetActive(false);
            TownOfBeginings.SetActive(false);
            DungonF1.SetActive(false);
        }
        else if (sceneName == "Chat")
        {
            ChatPlace.SetActive(true);
            BossF1.SetActive(false);
            TownOfBeginings.SetActive(false);
            DungonF1.SetActive(false);
        }
    }


}
