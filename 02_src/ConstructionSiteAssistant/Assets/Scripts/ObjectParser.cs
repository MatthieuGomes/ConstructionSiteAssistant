using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class BuildingElement : MonoBehaviour
{
    [SerializeField]
    public string elementType;

    [SerializeField]
    public string materials;

    [SerializeField]
    public int elementId;

    void Start()
    {
        // Commencer le parcours � partir du parent racine
        Transform mainParent = transform; 
        ParseObjects(mainParent);
    }

    // Fonction de parcours r�cursif
    void ParseObjects(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // logique de parsing
            ParseObject(child.gameObject);

            // Si l'objet a des enfants, appele  la fonction pour  la hi�rarchie
            if (child.childCount > 0)
            {
                ParseObjects(child);
            }
        }
    }

    // Fonction de parsing pour un objet donn�
    public void ParseObject(GameObject obj)
    {
        // R�cup�rer le nom actuel de l'objet
        string currentName = obj.name;

        // Diviser le nom pour obtenir seulement le nom de base
        string[] nameParts = currentName.Split(':');
        string baseName = currentName;

        // V�rifier si le nom est divis� correctement
        if (nameParts.Length >= 3)
        {
            // Prendre la partie du milieu comme nom de base
            baseName = nameParts[nameParts.Length - 2].Trim();

            // Assigner les valeurs aux variables publiques
            elementType = nameParts[0].Trim();
            materials = nameParts[nameParts.Length - 1].Trim();

            // V�rifier si elementId est un nombre valide
            int id;
            if (int.TryParse(nameParts[nameParts.Length - 2].Trim(), out id))
            {
                elementId = id;
            }
            else
            {
                Debug.LogError("Invalid elementId format: " + currentName);
                return;
            }
        }
        else
        {
            Debug.LogError("Invalid name format: " + currentName);
            return;
        }

        
        string newName = $"{elementType}_{materials}_{elementId}_{baseName}";
        obj.name = newName;

#if UNITY_EDITOR
        // Sert � signaler � Unity que l'objet a �t� modifi�
        EditorUtility.SetDirty(obj);
#endif
    }
}

