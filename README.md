# MediaTek86

## Présentation

MediaTek86 est une application bureau développée en C# avec Windows Forms.  
Elle permet de gérer les données liées au personnel et aux absences d’une médiathèque à partir d’une base de données MySQL.

L’application répond aux cas d’utilisation demandés dans le cadre de l’atelier professionnel :
- connexion à l’application par identifiant et mot de passe ;
- ajout, modification et suppression de personnel ;
- affichage, ajout, modification et suppression d’absences ;
- gestion des absences avec contrôle du chevauchement ;
- création d’un installeur fonctionnel.

## Contexte

Ce projet a été réalisé dans le cadre du devoir 2 de l’atelier de professionnalisation.  
L’objectif était de produire une application de type Windows Forms .NET Framework en C#, construite selon la même logique que l’application Habilitations, avec une base de données MySQL et une organisation du projet par dossiers.

Le projet repose sur une structure comportant notamment :
- un dossier `BddManager` pour la connexion à la base ;
- un dossier `dal` pour l’accès aux données ;
- un dossier `Controleur` ;
- un dossier `model` ;
- plusieurs formulaires Windows Forms pour l’interface.

## Technologies utilisées

- C#
- Windows Forms (.NET Framework)
- Visual Studio
- MySQL
- MySql.Data
- WampServer / phpMyAdmin
- Looping
- GitHub
- Visual Studio Installer Projects

## Base de données

La base de données `mediatek86` contient les tables suivantes :
- `personnel`
- `absence`
- `motif`
- `service`
- `responsable`

### Rôle des tables

- `personnel` : contient les informations des membres du personnel ;
- `service` : contient les services associés au personnel ;
- `absence` : contient les périodes d’absence du personnel ;
- `motif` : contient les motifs d’absence ;
- `responsable` : contient les identifiants de connexion à l’application.

### MCD

> Ajouter ici la capture d’écran du schéma Looping exporté depuis le fichier `.loo`.

Exemple :
```md

```

## Structure des relations

Le modèle de données repose sur les relations suivantes :
- un membre du personnel appartient à un seul service ;
- un service peut être associé à plusieurs membres du personnel ;
- un membre du personnel peut avoir plusieurs absences ;
- une absence possède un seul motif ;
- un motif peut être utilisé pour plusieurs absences.

## Interfaces

### Connexion

L’application démarre sur une fenêtre de connexion permettant à un responsable de s’authentifier.

> Ajouter ici la capture de la fenêtre de connexion  
```md

```

### Accueil

Une fois connecté, l’utilisateur accède au menu principal de l’application.

> Ajouter ici la capture du menu principal  
```md

```

### Gestion du personnel

Le formulaire Personnel permet :
- d’afficher la liste du personnel ;
- d’ajouter un employé ;
- de modifier un employé ;
- de supprimer un employé ;
- d’enregistrer les modifications.

> Ajouter ici la capture du formulaire personnel  
```md

```

### Gestion des absences

Le formulaire Absence permet :
- d’afficher les absences ;
- d’ajouter une absence ;
- de modifier une absence ;
- de supprimer une absence ;
- de contrôler les chevauchements avant enregistrement.

> Ajouter ici la capture du formulaire absence  
```md

```

## Diagramme de paquetages

Le projet est organisé selon une structure proche de celle demandée dans les consignes :

- `BddManager` : gestion de la connexion à la base de données ;
- `Controleur` : logique de contrôle ;
- `dal` : accès aux données ;
- `model` : classes et formulaires ;
- formulaires : `FormLogin`, `FormPersonnel`, `FormAbsence`, `MediaTek86`.

> Ajouter ici une image du diagramme de paquetages réalisée sur draw.io ou PowerPoint.  
```md

```

## Fonctionnalités

L’application permet de :
- se connecter à l’aide d’un compte responsable ;
- ajouter un personnel ;
- supprimer un personnel ;
- modifier un personnel ;
- afficher les absences ;
- ajouter une absence ;
- supprimer une absence ;
- modifier une absence ;
- empêcher l’ajout ou la modification d’une absence en cas de chevauchement.

## Étapes de construction

### Étape 1 — Installation des outils
- installation de Visual Studio ;
- installation de WampServer ;
- installation de Looping ;
- installation des dépendances nécessaires au projet.

### Étape 2 — Création de la base de données
- conception du schéma sous Looping ;
- export du schéma au format SQL ;
- import du script dans phpMyAdmin ;
- insertion des données de base.

### Étape 3 — Design de l’application
- conception des maquettes ;
- personnalisation de l’interface Windows Forms ;
- harmonisation des couleurs, boutons et formulaires.

### Étape 4 — Programmation
- mise en place de la connexion à la base ;
- développement des formulaires ;
- implémentation du CRUD du personnel ;
- implémentation du CRUD des absences ;
- ajout du contrôle du chevauchement.

### Étape 5 — Versionnement et sauvegarde
- mise en place du dépôt GitHub ;
- sauvegardes du projet ;
- documentation du projet.

### Étape 6 — Installeur
- création d’un projet d’installation ;
- ajout de la sortie principale du projet ;
- génération et test du fichier d’installation.

## Installation

### Prérequis
- Windows ;
- Visual Studio ;
- WampServer / MySQL ;
- package `MySql.Data`.

### Procédure
1. Cloner ou télécharger le projet.
2. Importer le fichier `mediatek86.sql` dans phpMyAdmin.
3. Vérifier les paramètres de connexion dans `App.config`.
4. Ouvrir la solution dans Visual Studio.
5. Restaurer les packages NuGet si nécessaire.
6. Compiler le projet.
7. Lancer l’application ou utiliser l’installeur.

## Démonstration vidéo

> Ajouter ici le lien vers la vidéo de démonstration :

```md
[Voir la vidéo de démonstration](LIEN_VIDEO_ICI)
```

## Dépôt GitHub

> Ajouter ici le lien vers le dépôt :

```md
[Voir le dépôt GitHub](LIEN_DEPOT_ICI)
```

## Auteur

Jules G, Projet réalisé dans le cadre de l’atelier de professionnalisation.