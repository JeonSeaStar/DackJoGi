using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static OpenDoor Instance;

    public GameObject door;

    public void Awake()
    {
        Instance = this;
    }

    public void OpenDoorB()
    {
        door.transform.rotation = Quaternion.Euler(-130, 90, 90);
    }
}
