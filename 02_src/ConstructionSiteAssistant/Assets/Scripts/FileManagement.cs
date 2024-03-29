using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManagement : MonoBehaviour
{
    string m_Path;
    List<string> required_files = new List<string> {"idToIngredients.csv","onSiteMaterials.csv","onCenterMaterial.csv","constructionSiteState.csv"};
    // Start is called before the first frame update
    void Start()
    {
        m_Path = Application.dataPath;
        RequirementCheck();
    }

    public void RequirementCheck()
    {
        string data_path= m_Path + "/" + "datas";
        
        if (!(System.IO.Directory.Exists(data_path)))
        {
            System.IO.Directory.CreateDirectory(data_path);
        }
        foreach (string f in required_files)
        {
            string filePath = Path.Combine(data_path, f);
            if (!(System.IO.File.Exists(filePath)))
            {
                System.IO.File.Create(filePath);
                FilePopulation(filePath);
            }
        }
 
    }

    public void FilePopulation(string fileToCreate)
    {
        String contents;
        switch (fileToCreate)
        {
            case "idToIngredients.csv":
                contents = "";
                // Decrire les instructions pour écrire le fichier
                break;
            case "onSiteMaterials.csv":
                contents = "";
                // Decrire les instructions pour écrire le fichier
                break;
            case "onCenterMaterial.csv":
                contents = "";
                // Decrire les instructions pour écrire le fichier
                break;
            case "constructionSiteState.csv":
                contents = "";
                // Decrire les instructions pour écrire le fichier
                break;
            default:
                contents = "";
                Console.WriteLine("Everything seems fine");
                break;
        }
        System.IO.File.WriteAllText(fileToCreate, contents);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
