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
        // Commencer le parcours à partir du parent racine
        Transform mainParent = transform; 
        ParseObjects(mainParent);
    }

    // Fonction de parcours récursif
    void ParseObjects(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // logique de parsing
            ParseObject(child.gameObject);

            // Si l'objet a des enfants, appele  la fonction pour  la hiérarchie
            if (child.childCount > 0)
            {
                ParseObjects(child);
            }
        }
    }

    // Fonction de parsing pour un objet donné
    public void ParseObject(GameObject obj)
    {
        // Récupérer le nom actuel de l'objet
        string currentName = obj.name;

        // Diviser le nom pour obtenir seulement le nom de base
        string[] nameParts = currentName.Split(':');
        string baseName = currentName;

        // Vérifier si le nom est divisé correctement
        if (nameParts.Length >= 3)
        {
            // Prendre la partie du milieu comme nom de base
            baseName = nameParts[nameParts.Length - 2].Trim();

            // Assigner les valeurs aux variables publiques
            elementType = nameParts[0].Trim();
            materials = nameParts[nameParts.Length - 1].Trim();

            // Vérifier si elementId est un nombre valide
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
        // Sert à signaler à Unity que l'objet a été modifié
        EditorUtility.SetDirty(obj);
#endif
    }
}

