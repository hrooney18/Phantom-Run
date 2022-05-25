using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAppearScript2 : MonoBehaviour
{
    private bool spikesMoved;
    private bool grassMoved;
    private bool checkpointMoved;
    GameObject[] appearingSpikes;
    GameObject[] appearingGrass;
    GameObject[] disappearingSpikes;
    GameObject[] disappearingGrass;
    GameObject[] appearingDisappearingSpikes;
    GameObject[] appearingDisappearingGrass;

    void Start()
    {
        spikesMoved = false;
        grassMoved = false;
        checkpointMoved = false;
        appearingSpikes = GameObject.FindGameObjectsWithTag("Appearing Spike 2");
        appearingGrass = GameObject.FindGameObjectsWithTag("Appearing Grass Block 2");
        disappearingSpikes = GameObject.FindGameObjectsWithTag("Disappearing Spike 2");
        disappearingGrass = GameObject.FindGameObjectsWithTag("Disappearing Grass Block 2");
        appearingDisappearingSpikes = GameObject.FindGameObjectsWithTag("Appearing Spike 1/Disappearing 2");
        appearingDisappearingGrass = GameObject.FindGameObjectsWithTag("Appearing Grass 1/Disappearing 2");
    }

    void OnTriggerEnter2D()
    {
        DestroyBlocks(appearingDisappearingSpikes);
        DestroyBlocks(appearingDisappearingGrass);
        DestroyBlocks(disappearingSpikes);
        DestroyBlocks(disappearingGrass);
        AppearBlocks(appearingSpikes, spikesMoved);
        spikesMoved = true;
        AppearBlocks(appearingGrass, grassMoved);
        grassMoved = true;
        if (!checkpointMoved)
        {
            GameObject flag = GameObject.FindGameObjectWithTag("Appearing Checkpoint 3");
            GameObject touchedFlag = GameObject.FindGameObjectWithTag("Appearing Touched Flag 3");
            Vector3 position = flag.transform.position;
            Vector3 touchedPosition = touchedFlag.transform.position;
            position = new Vector3(position.x - 40, position.y, position.z);
            touchedPosition = new Vector3(touchedPosition.x - 40, position.y, position.z);
            flag.transform.position = position;
            touchedFlag.transform.position = touchedPosition;
            checkpointMoved = true;
        }
    }

    void DestroyBlocks(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    void AppearBlocks(GameObject[] objects, bool objectsMoved)
    {
        foreach (GameObject obj in objects)
        {
            if (!objectsMoved)
            {
                Vector3 position = obj.transform.position;
                position = new Vector3(position.x - 40, position.y, position.z);
                obj.transform.position = position;
            }
        };
    }
}
