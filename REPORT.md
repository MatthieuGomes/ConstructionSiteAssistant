# ConstructionSiteAssistant : Rapport de projet

## Convertir un fichier IFC (BIM) en un fichier compatible Unity conservant la hierarchie des objets

On utilise ifcConvert en jouant sur les paramètres. Il faut exporter le BIM au format .dae avec des paramètres permettant de conserver les informations souhaités.

Téléchargement et installation de ifcConvert : https://ifcopenshell.sourceforge.net/ifcconvert.html

Documentation sur l’utilisation : https://blenderbim.org/docs-python/ifcconvert/usage.html

La commande permettant l’exportation d’un modèle en un format admis par Unity, qui conserve les hierarchies, les ID, les noms des éléments et des matériaux :
~~~
.\IfcConvert.exe path\input.ifc path\output.dae --use-element-hierarchy --use-element-names --use-material-names
~~~
Le fichier final est une version .dae de l’ifc spécifié en entrée qui a conservé la hiérarchie des éléments ainsi que les noms spécifiés précédemment.
