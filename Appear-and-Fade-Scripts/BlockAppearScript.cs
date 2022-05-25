using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAppearScript : MonoBehaviour
{
    private bool spikesMoved;
    private bool grassMoved;
    private bool otherSpikesMoved;
    private bool otherGrassMoved;
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
        otherSpikesMoved = false;
        otherGrassMoved = false;
        appearingSpikes = GameObject.FindGameObjectsWithTag("Appearing Spike");
        appearingGrass = GameObject.FindGameObjectsWithTag("Appearing Grass Block");
        disappearingSpikes = GameObject.FindGameObjectsWithTag("Disappearing Spike");
        disappearingGrass = GameObject.FindGameObjectsWithTag("Disappearing Grass Block");
        appearingDisappearingSpikes = GameObject.FindGameObjectsWithTag("Appearing Spike 1/Disappearing 2");
        appearingDisappearingGrass = GameObject.FindGameObjectsWithTag("Appearing Grass 1/Disappearing 2");
    }

    void OnTriggerEnter2D()
    {
        DestroyBlocks(disappearingSpikes);
        DestroyBlocks(disappearingGrass);
        AppearBlocks(appearingSpikes, spikesMoved);
        spikesMoved = true;
        AppearBlocks(appearingGrass, grassMoved);
        grassMoved = true;
        AppearBlocks(appearingDisappearingGrass, otherGrassMoved);
        otherGrassMoved = true;
        AppearBlocks(appearingDisappearingSpikes, otherSpikesMoved);
        otherSpikesMoved = true;
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
                position = new Vector3(position.x, position.y - 20, position.z);
                obj.transform.position = position;
            }
        };
    }
}
