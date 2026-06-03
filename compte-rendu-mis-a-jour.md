# Compte rendu — Projet MediaTek86
**Atelier de professionnalisation — Devoir 2**  
**Auteur : Jules**

---

## 1. Présentation du projet

MediaTek86 est une application bureau développée en C# avec Windows Forms dans le cadre du devoir 2 de l'atelier de professionnalisation. Elle permet de gérer la base de données d'une médiathèque fictive : gestion du personnel, suivi des absences et authentification des responsables.

L'application est connectée à une base de données MySQL locale et repose sur une architecture structurée en couches, selon le modèle imposé par les consignes.

---

## 2. Contexte et objectifs

L'objectif de ce projet est de produire une application de type Windows Forms en C# / .NET Framework, construite selon la même logique que l'application Habilitations étudiée en cours. Les fonctionnalités attendues sont les suivantes :

- connexion sécurisée à l'application via un compte responsable ;
- gestion complète (CRUD) des membres du personnel ;
- gestion complète (CRUD) des absences ;
- contrôle du chevauchement des absences ;
- création d'un installeur Windows fonctionnel.

---

## 3. Technologies utilisées

| Technologie | Rôle |
|---|---|
| C# / .NET Framework 4.8 | Langage principal de développement |
| Windows Forms | Interface graphique bureau |
| Visual Studio 2022 | Environnement de développement intégré |
| MySQL | Base de données relationnelle |
| MySql.Data (NuGet) | Connecteur MySQL pour C# |
| WampServer / phpMyAdmin | Serveur MySQL local et administration |
| Looping | Conception du modèle conceptuel de données |
| GitHub | Versionnement et sauvegarde du projet |
| Visual Studio Installer Projects | Création de l'installeur Windows (.msi) |

---

## 4. Base de données

### 4.1 Tables et rôles

La base de données `mediatek86` est composée de cinq tables :

| Table | Rôle |
|---|---|
| `service` | Contient les services de la médiathèque |
| `personnel` | Contient les membres du personnel (nom, prénom, téléphone, mail, service) |
| `absence` | Contient les périodes d'absence (idpersonnel, datedebut, datefin, idmotif) |
| `motif` | Contient les motifs d'absence (vacances, maladie, motif familial, congé parental) |
| `responsable` | Contient les identifiants de connexion à l'application |

### 4.2 Relations entre les tables

- Un service peut regrouper plusieurs membres du personnel.
- Un membre du personnel peut avoir plusieurs absences.
- Chaque absence est associée à un seul motif.
- L'entité `responsable` est indépendante et sert uniquement à l'authentification.

### 4.3 Modèle Conceptuel de Données (MCD)

> Insérer ici l'image : `docs/mcd.png`

Le modèle conceptuel de données de MediaTek86 repose sur cinq entités : `service`, `personnel`, `absence`, `motif` et `responsable`. Un service peut regrouper plusieurs membres du personnel, un membre du personnel peut posséder plusieurs absences, et chaque absence est associée à un seul motif. L'entité `responsable` est utilisée pour l'authentification à l'application.

---

## 5. Architecture du projet

### 5.1 Diagramme de paquetages

> Insérer ici l'image : `docs/diagramme_paquetages.png`

Le projet MediaTek86 est organisé sous la forme d'une application Windows Forms structurée en plusieurs couches. Le dossier `BddManager` gère la connexion à la base de données, le dossier `dal` centralise l'accès aux données, le `Controleur` assure la liaison entre l'interface et la logique métier, tandis que les formulaires WinForms constituent l'interface utilisateur de l'application.

### 5.2 Structure des dossiers

```
MediaTek86/
├── BddManager/       → Gestion de la connexion à la base de données
├── Controleur/       → Logique de contrôle entre interface et données
├── dal/              → Couche d'accès aux données (requêtes SQL)
├── model/            → Classes métier
├── FormLogin         → Formulaire de connexion
├── MediaTek86        → Formulaire d'accueil (menu principal)
├── FormPersonnel     → Formulaire de gestion du personnel
├── FormAbsence       → Formulaire de gestion des absences
└── App.config        → Paramètres de connexion à la base
```

---

## 6. Interfaces de l'application

### 6.1 Formulaire de connexion

> Insérer ici l'image : `docs/login.png`

Le formulaire de connexion est le point d'entrée de l'application. Le responsable saisit son identifiant (login) et son mot de passe. La vérification est effectuée en base de données via la table `responsable`. En cas d'erreur, un message informe l'utilisateur.

---

### 6.2 Formulaire d'accueil

> Insérer ici l'image : `docs/home.png`

Une fois authentifié, le responsable accède au menu principal. Deux boutons de navigation permettent d'ouvrir le formulaire du personnel ou le formulaire des absences.

---

### 6.3 Formulaire de gestion du personnel

> Insérer ici l'image : `docs/personnel.png`

Ce formulaire affiche la liste de tous les membres du personnel dans un DataGridView. Il permet :
- d'ajouter un nouveau membre directement dans le tableau ;
- de modifier les informations d'un membre existant ;
- de supprimer un membre ;
- d'enregistrer toutes les modifications en base de données via le bouton « Enregistrer les modifications ».

---

### 6.4 Formulaire de gestion des absences

> Insérer ici l'image : `docs/absence.png`

Ce formulaire affiche la liste de toutes les absences enregistrées dans un DataGridView. Il permet :
- d'ajouter une nouvelle absence ;
- de modifier une absence existante ;
- de supprimer une absence ;
- d'enregistrer les modifications en base de données.

Avant tout enregistrement, une vérification automatique est effectuée pour détecter les chevauchements : si un même employé possède déjà une absence dont la période chevauche celle saisie, un message d'avertissement s'affiche et l'opération est annulée.

---

## 7. Fonctionnalités détaillées

### Authentification
- Vérification des identifiants en base via la table `responsable`.
- Affichage d'un message d'erreur en cas d'échec.
- Redirection vers l'accueil en cas de succès.

### Gestion du personnel (CRUD)
- Affichage de la liste complète du personnel.
- Ajout d'un nouveau membre (INSERT).
- Modification d'un membre existant (UPDATE).
- Suppression d'un membre (DELETE).
- Sauvegarde des modifications en base.

### Gestion des absences (CRUD)
- Affichage de la liste complète des absences.
- Ajout d'une nouvelle absence (INSERT) avec contrôle de chevauchement.
- Modification d'une absence existante (UPDATE) avec contrôle de chevauchement.
- Suppression d'une absence (DELETE).
- Sauvegarde des modifications en base.

### Contrôle de chevauchement
- Pour un même employé, deux absences ne peuvent pas avoir des périodes qui se superposent.
- La vérification est effectuée via une requête SQL `COUNT(*)` avant chaque INSERT ou UPDATE.
- En cas de chevauchement détecté, un message explicite s'affiche et l'opération est bloquée.

---

## 8. Étapes de construction

### Étape 1 — Installation des outils
Installation de Visual Studio 2022, WampServer, Looping et des packages NuGet nécessaires au projet.

### Étape 2 — Création de la base de données
Conception du MCD sous Looping, export au format SQL, import dans phpMyAdmin et insertion des données initiales.

### Étape 3 — Design de l'application
Conception des maquettes des formulaires, personnalisation de l'interface Windows Forms (palette de couleurs sombre, police Segoe UI, boutons stylisés).

### Étape 4 — Programmation
Mise en place de la connexion à la base via `BddManager`, développement des quatre formulaires, implémentation du CRUD complet pour le personnel et les absences, ajout du contrôle de chevauchement.

### Étape 5 — Versionnement et sauvegarde
Initialisation du dépôt GitHub, sauvegardes régulières, rédaction de la documentation.

### Étape 6 — Installeur
Création du projet d'installation via Visual Studio Installer Projects, ajout de la sortie principale et des dépendances, génération du fichier `.msi`.

---

## 9. Installation et lancement

### Prérequis
- Windows 10 ou supérieur
- Visual Studio 2022
- WampServer avec MySQL actif
- Package NuGet `MySql.Data`

### Procédure
1. Cloner ou télécharger le projet.
2. Lancer WampServer et activer MySQL.
3. Importer `mediatek86.sql` dans phpMyAdmin.
4. Vérifier les paramètres dans `App.config` (Server, Database, User Id, Password).
5. Ouvrir `MediaTek86.sln` dans Visual Studio.
6. Restaurer les packages NuGet si nécessaire.
7. Compiler et lancer avec F5, ou utiliser l'installeur `.msi`.

---

## 10. Démonstration vidéo

> Lien de la vidéo: `#`


---

## 12. Conclusion

Le projet MediaTek86 répond à l'ensemble des exigences du devoir 2 de l'atelier de professionnalisation. L'application permet la gestion complète du personnel et des absences d'une médiathèque, avec une interface sobre et moderne, une connexion sécurisée, un contrôle métier sur les chevauchements d'absences, et un installeur Windows fonctionnel.
