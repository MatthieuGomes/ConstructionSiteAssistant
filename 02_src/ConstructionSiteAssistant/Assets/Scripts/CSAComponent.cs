/*
 * Author: Saïd Sahnoune & Oliver Belliard Abreu
 * Project: ENSEA 2d year project "Construction Site Assistant" (CSA).
 * Description: Sets the data of curent Game Object to fit the specifications of the CSA.
 */

using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class CSAComponent : MonoBehaviour
{
    [SerializeField]
    public string elementType;
    [SerializeField]
    public string elementMaterial;
    [SerializeField]
    public int elementId;
    [SerializeField]
    public string defaultElementName;
    [SerializeField]
    public Material defaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        ParseName(this.gameObject);
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Parse name of a Game Object to extract it's data
    public void ParseName(GameObject obj)
    {
        // Retrieve current object name
        defaultElementName = obj.name;

        // Split the name to extract the different parameters
        string[] nameParts = defaultElementName.Split(':');

        // Check that the name has been divided correctly
        if (nameParts.Length >= 3)
        {
            // Assigning values to the public variables
            elementType = nameParts[0].Trim();
            elementMaterial = nameParts[1].Trim();

            // Check if the element id is a valid number
            int id;
            if (int.TryParse(nameParts[2].Trim(), out id))
            {
                elementId = id;
            }
            else
            {
                Debug.LogError("Invalid elementId format: " + defaultElementName);
                return;
            }
        }
        else
        {
            Debug.LogError("Invalid name format: " + defaultElementName);
            return;
        }

        obj.name = elementType;

#if UNITY_EDITOR
        // Notifies the Unity editor that the object has been modified
        EditorUtility.SetDirty(obj);
#endif
    }

    //
    // EVENT FUNCTIONS
    //
    // Changes the material on hover
    public void SwitchToHoverMaterial(Material material)
    {
        if (material != defaultMaterial)
        {
            GetComponent<MeshRenderer>().material = material;
        }
    }

    // Switches the material back to the original material when there's no interaction
    public void SwitchBackToDefaultMaterial()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    // Changes the mesh material to a random material from a given list
    public void SetRandomMaterial(Material[] materials)
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
    }
}
