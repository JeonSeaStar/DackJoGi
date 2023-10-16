using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static OpenDoor Instance;

    public GameObject door;
    public GameObject door1;

    public void Awake()
    {
        Instance = this;
    }

    public void OpenDoorB()
    {
        door.SetActive(false);
        door1.SetActive(true);
    }
}
