﻿using System.Collections.Generic;
using UnityEngine;

public abstract class Synapse : MonoBehaviour, ISynapseConnection {


    public Node AccessibleNode
    {
        get { return to;}
        set { to = value; }
    }
    public float Weight { get; set; }

    public Node from { get; set; }
    public Node to { get; set; }

    private LineRenderer line;

    protected float lastTransmissionStart;

    // Use this for initialization
    public void Start ()
    {
        lastTransmissionStart = Time.time;

        line = gameObject.AddComponent<LineRenderer>();
        drawConnection();

        registerSynapse();
    }

    void registerSynapse()
    {
        Weight = Vector3.Distance(from.transform.position, to.transform.position);
        from.AddConnection(this);
//        to.AddConnection(new SynapseConnection { AccessibleNode = from, Weight = this.Weight }); // as long as synapses are non directional
    }

    void drawConnection()
    {
        line.useWorldSpace = false;
        line.positionCount = 2;
        line.SetPosition(0, from.transform.position);
        line.SetPosition(1, to.transform.position);
        line.startColor = Color.white;
        line.endColor = Color.white;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material.color = Color.white;
        line.numCornerVertices = 10;
    }

    public bool transferData(Data_Script data, IGraphSearch transfer)
    {
        if (this.canTransfer(data.shape))
        {
            lastTransmissionStart = Time.time;

            Vector3 ownCoords = transfer.CurrentNode.transform.position;
            Vector3 connCoords = data.transform.position;

            Vector3 way = ownCoords - connCoords;
            data.gameObject.AddComponent<MovementController>();
            data.gameObject.GetComponent<MovementController>().way = way;
            data.gameObject.GetComponent<MovementController>().synapse = this;

            data.gameObject.GetComponent<MovementController>().finish = connCoords;
            var speed = 4;
            data.gameObject.GetComponent<MovementController>().speed = speed;

            data.gameObject.GetComponent<MovementController>().callback = () =>
            {
                var destination = AccessibleNode.gameObject.GetComponent<NodeDataSpawner>();
                destination.addData(data);
            };
            return true;
        }
        return false;
    }

    public abstract float getProgress();


    public void MoveDataOnce(List<IGraphSearch> path, Data_Script d)
    {
    }

    public abstract bool canTransfer(Shape data);
}
