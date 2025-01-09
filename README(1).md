
# Hackathon : Accès Hémicycle

Ce projet est un hackathon dont la période de celui-ci s'est déroulée du 06/01/2025 au 09/01/2025.
### Contexte du projet
Pour renforcer la sécurité des députés siégeant à l'Assemblée nationale, il a été décidé de fournir un nouveau badge contenant un QR Code. Un sas de sécurité aux endroits qui ne sont accessibles qu'aux députés contrôlera l'ensemble des accès via leur QR Code personnel. Et je suis chargé de créer une application permettant de scanner ces QR Code afin de pouvoir valider l'entrée dans l'hémicycle en vérifiant les informations incluses.





## Outils utilisés

 - Programmation orientée object avec le langage C# et le framework .Net.
 - une base de données sur le serveur scolaire.

## Deployment

Pour installer l'application, il suffit de récupérer l'ensemble du projet C# et la base de données. 
- https://github.com/Tijack-chv/AccesHemicycle.git

Le script de la base de données se trouve dans un fichier à la racine du projet :
- /Database/scriptBDD-AccesHemicycle 




## Demo

(Insertion du lien de la vidéo gif)

L'application permet de vérifier les personnes voulant accéder à l'hémicycle.
Dans un premier temps, au niveau de la page d'accueil, vous pouvez choisir la caméra que vous voulez utiliser pour scanner les Qr Code parmi une liste présente à droite de la page. Le bouton 'lancer' permet d'activer la caméra, et le bouton qui apparaît ensuite permet de scanner la caméra à l'instant du clic. Il va dans un premier temps vérifier que le QR Code est de type V Card. Ensuite, il compare l'id, le nom, le prénom et l'adresse-email renseignés dans le QR Code avec les informations dans la base de données. Si une réponse positive est retournée, les informations du député sont affichées à l'écran et un enregistrement est exécuté dans la base de données sur l'entrée dans l'hémicycle de cette personne.\
Dans un deuxième temps, vous pouvez accéder à la page des députés dont une demande de connexion est nécessaire avec l'email et mot de passe suivant : 'admin@droitAN.fr', 'adminpassword'.\
Cette page ouvre un tableau avec l'ensemble des députés actif, avec un système de pagination et une barre de recherche sur le nom et/ou le prénom. Vous avez la possibilité d'ouvrir la photo du député via un clic droit sur le député sélectionné sur la datagridview. Et vous pouvez également accepter qu'un député puisse entrer dans l'hémicycle sans carte (dans le cas par exemple où celui-ci n'a pas sa carte mais arrive à prouver son identité). Il est alors, de la même manière que sur l'accès basique, enregistré sur la date et l'heure de son entrée dans l'hémicycle. En plus, une ligne dans les logs est saisie sur son entrée, puisqu'elle n'est pas celle prévue.\
Vous pouvez également afficher la page plan de l'hémicycle qui est simplement l'affichage du plan de celui-ci.\
Vous pouvez également accéder aux réseaux sociaux de l'Assemblée nationale en haut de l'application.


## Explications des choix

L'utilisation du langage C# avec le framework .Net pour une application côté serveur a été réalisée pour plusieurs raisons : 
- Le temps de l'hackathon étant plutôt court (4 jours), le fait d'utiliser un langage avec une bonne maîtrise était nécessaire.
- L'application avec C# peut être combinée avec une scanette qui rendrait l'utilisation très rapide de celle-ci. Et il est plus facile également d'avoir une plus grande multitude de choix sur l'élément scannant le QR Code.
- Avec l'utilisation d'une base de données, il était plus simple de faire une application qui puisse accéder à ces éléments qu'une autre qui, par exemple,nécessiterait de passer par une API pour récupérer ces fameuses données.
## Authors

- [@Tijack-chv](https://www.github.com/Tijack-chv)

