# ConstructionSiteAssistant

## Useful links
- Trello: https://trello.com/w/projetassistantchantier2a/members
- Démarche, objectifs et ordre de développement sur [Notion](https://oliver-benjamin.notion.site/adea81ec6a7540518e80d6fe5fd57195?v=632ea0d2a33b4f16ba4129930be465de&pvs=4).
- Techniques de l'Ingénieur: https://www.techniques-ingenieur.fr
- Sotfware used to visualized *.ifc files : https://www.evebim.fr

## Version unity utilisée
2022.3.10f1 --> 2022.3.18f1

## Convertion d'un *.ifc file (BIM) manuellement en fichier 3D pour Unity 3D file (here *.dae):
On peut utiliser ifcConvert et jouer sur les paramètres. Il faut exporter le BIM au format .dae avec des paramètres permettant de conserver les informations souhaités.

> Téléchargement et installation de ifcConvert : [ifcConvert](https://ifcopenshell.sourceforge.net/ifcconvert.html)  
> Documentation sur l’utilisation : https://blenderbim.org/docs-python/ifcconvert/usage.html

La commande permettant l’exportation d’un modèle en un format admis par Unity, qui conserve les hierarchies, les ID, les noms des éléments et des matériaux :
```
.\IfcConvert.exe path\input.ifc path\output.dae --use-element-hierarchy --use-element-names --use-material-names
```
Le fichier final est une version .dae de l’ifc spécifié en entrée qui a conservé la hiérarchie des éléments ainsi que les noms spécifiés précédemment.

