using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        ParseName(this.gameObject);
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
}
