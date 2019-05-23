using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMod;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class BoxScript : ModScript
{
    public GameObject object_left = null;
    public GameObject indicator_left = null;
    public MeshRenderer[] mrs_left = null;
    public MeshFilter[] mfs_left = null;

    public GameObject object_right = null;
    public GameObject indicator_right = null;
    public MeshRenderer[] mrs_right = null;
    public MeshFilter[] mfs_right = null;

    public override void OnModLoaded()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public override void OnModUpdate()
    {
        if (object_left != null)
        {
            if (indicator_left != null)
            {
                object_left.transform.position = indicator_left.transform.position;
                object_left.transform.rotation = indicator_left.transform.rotation;
            }
            else
            {
                indicator_left = GameObject.Find("Left Indicator");
                mfs_left = indicator_left.GetComponentsInChildren<MeshFilter>();
                mfs_left[0].sharedMesh = null;
                mfs_left[1].sharedMesh = null;

                mrs_left = indicator_left.GetComponentsInChildren<MeshRenderer>();
                object_left.GetComponent<MeshRenderer>().material = mrs_left[1].material;
            }
        }

        if (object_right != null)
        {
            if (indicator_right != null)
            {
                object_right.transform.position = indicator_right.transform.position;
                object_right.transform.rotation = indicator_right.transform.rotation;
            }
            else
            {
                indicator_right = GameObject.Find("Right Indicator");
                mfs_right = indicator_right.GetComponentsInChildren<MeshFilter>();
                mfs_right[0].sharedMesh = null;
                mfs_right[1].sharedMesh = null;

                mrs_right = indicator_right.GetComponentsInChildren<MeshRenderer>();
                object_right.GetComponent<MeshRenderer>().material = mrs_right[1].material;
            }
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name.Contains("Stage"))
        {
            object_left = ModAssets.Instantiate<GameObject>("BoxL");
            object_left.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            object_right = ModAssets.Instantiate<GameObject>("BoxR");
            object_right.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
        }
    }

    public override void OnModUnload()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

}
