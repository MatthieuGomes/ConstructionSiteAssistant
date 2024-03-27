/*
 * Author: Oliver Belliard Abreu
 * Project: ENSEA 2d year project "Construction Site Assistant".
 * Description: Main script, manages or triggers the setup of all game objects of the scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Surfaces;
using Oculus.Interaction;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] interactiveObjects;
    [SerializeField]
    public bool makeChildrenInteractive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set up of all 
        foreach (GameObject parentObject in interactiveObjects)
        {
            // We make the object and its children interactable
            RecursiveChildrenStartMethod(parentObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Recursive call to set up all selected child GameObjects at Startup
    private void RecursiveChildrenStartMethod(GameObject obj)
    {
        // Operations to execute on children
        // We attach a CSA Component data model to the current object
        obj.AddComponent<CSAComponent>();
        // We turn the current object ray interactable
        MakeRayInteractable(obj);

        // We retrieve all childen in current child
        foreach (GameObject child in GetAllChildren(obj))
        {
            // Recursive call for each child of child
            RecursiveChildrenStartMethod(child);
        }
    }

    // Makes GameObjects with a Mesh ray interactable
    public void MakeRayInteractable(GameObject obj)
    {
        if (obj.GetComponent<MeshRenderer>() != null)
        {
            MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
            Mesh meshToCollide = meshFilter.mesh;

            // We add the necessary components to turn our game object interactable
            MeshCollider meshCollider = obj.AddComponent<MeshCollider>();
            ColliderSurface colliderSurface = obj.AddComponent<ColliderSurface>();
            RayInteractable rayInteractable = obj.AddComponent<RayInteractable>();

            // We set up the added components
            meshCollider.sharedMesh = meshToCollide;
            colliderSurface.InjectCollider(meshCollider);
            rayInteractable.InjectSurface(colliderSurface);
        }
    }

    // Retrieves all the children of a GameObject
    public GameObject[] GetAllChildren(GameObject obj)
    {
        GameObject[] children;
        children = new GameObject[obj.transform.childCount];

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            children[i] = obj.transform.GetChild(i).gameObject;
        }

        return children;
    }
}

/* Useful resources used to achieve this script:
 * HasComponent method explanation: https://stackoverflow.com/questions/35166730/how-to-check-if-a-game-object-has-a-component-method-in-unity
 * 
 */
