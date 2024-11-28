https://www.youtube.com/watch?v=EmV_IBYIlyo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=5
https://drive.google.com/file/d/1EbYYjY7ubkpVKgBVE3Dloa9tr-oqo58g/view
________________________________________tutorial api aspnet + diagram pokemon_______________________
https://www.youtube.com/watch?v=NYpOaPC6jrg
________________explicacion de [fromquery]/[frombody etc]_________

----------------->EN LA CLASS POKEMON HAY EXPLICACIONES EN EL POKEOMON todos los files.<-----------------

�CREO LOS MODELS, EL DATACONTEXT..

�DB: Creo una DB con el SSMS...
1-Clickderecho en databsases dentro del servidor SSMS y Crear nueva database
(el paso 2 no hace falta pq ya estoy conectado a este servidor)
2-Accedemos al ssms copiamos el nombre del servidor(DESKTOP-14D02GT\SQLEXPRESS01)
y en Explorador de ServerObject(explorador de objetos SQL Server) en VisualStudio creamos un nuevo server con este mismo nombre y nos conectamos
a la db creada anteriormente. (en mi caso ya estoy conectado al server por otros proyectos)
3-Vamos a las propiedades dela database desde SQLVisualstudio y la (cedana de conexion) de la db la copiamos y lo ponemos
en el conecctionsetting (defaultconnedction) del apsettings.json.
"ConnectionStrings": {
        "DefaultConnection": "Data Source=DESKTOP-14D02GT\\SQLEXPRESS01;Initial Catalog=BlazorEleccions;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
    },
4-instalar el EntityFrameworkCore, SQLServer, Design, Tools.  +Automapper, quizas
tambien el automapper dependency injeccion.
5-Creamos el dbCOntext en la carpeta Data
6-configuramos en el program.cs que se conecte al defaultconnection(que hemos establecido)
7-Usamos la consola nugget:
//Comandos para inicializar la Migracion una vez se ha creado o modificado las clases y por lo tanto
        //Se habran modificado las tablas: Comando:::
        //EntityFrameworkCore\Add-Migration (Migration'sName)
        //Despu�s de esto el comando para actualizar la Database es:
        //EntityFrameworkCore\Update-DataBase

--->((Para que el paso 7 funcione bine necesito las relaciones bien especificadas))<---


�CREO LAS INTERFACES, RESPOSITORY, DTO, HELPER..

(para implementar SignalR, creamos una carpeta hub y dentro puede ser u metodo vacio por ejemplo ya que en
el controller es donde pondremos la Interface de Hub (IHub) para poder luego desde el front esucharlo)
_________________________________________________________
Recomendaci�n para el Proyecto Electoral
Dado que se espera una alta concurrencia en un entorno electoral, Blazor WebAssembly es probablemente la opci�n m�s adecuada por las siguientes razones:

Reducci�n de carga en el servidor: La aplicaci�n WebAssembly ejecuta la mayor�a de la l�gica de negocio en el cliente, reduciendo las conexiones activas en el servidor y, por tanto, la posibilidad de colapsos bajo alta concurrencia.

Escalabilidad: WebAssembly permite un n�mero mucho mayor de usuarios concurrentes, ya que la carga del servidor se limita a las operaciones de API (como el env�o de votos y la recuperaci�n de resultados), en lugar de mantener una conexi�n abierta para cada usuario.

Descentralizaci�n del procesamiento: Con WebAssembly, el navegador del usuario realiza el procesamiento de la interfaz, mientras que el servidor solo se encarga de las operaciones de API. Esto ayuda a evitar cuellos de botella en el servidor.

Implementaci�n y Gesti�n de las Votaciones
API Rest o SignalR para eventos importantes:

API Rest: Puedes usar API REST para operaciones CRUD (como env�o de votos y recuperaci�n de resultados).
SignalR en WebAssembly: Aunque Blazor WebAssembly no mantiene conexiones persistentes, puedes implementar SignalR en el servidor para eventos cr�ticos (como actualizaci�n en tiempo real de resultados) sin la carga constante que tendr�a en Blazor Server.
Escalabilidad de Base de Datos:

Es crucial que la base de datos est� optimizada para manejar escrituras r�pidas y m�ltiples conexiones. Considera usar bases de datos en la nube que ofrezcan escalabilidad autom�tica, como Azure Cosmos DB, Amazon DynamoDB, o una base de datos SQL con capacidad de escalado horizontal.
Colas de Mensajes (Message Queues):

Para manejar altas cargas de votaci�n en tiempo real, podr�as implementar colas de mensajes (como Azure Queue Storage, Amazon SQS, o RabbitMQ) para distribuir las operaciones de escritura. Cada voto se agrega a la cola y luego se procesa de forma as�ncrona, evitando una sobrecarga directa en la base de datos.
Balanceo de Carga y CDN:

Utilizar un CDN (Content Delivery Network) para servir los recursos est�ticos de la aplicaci�n WebAssembly y un balanceador de carga para distribuir el tr�fico entre m�ltiples instancias del backend puede mejorar la resiliencia y velocidad de la aplicaci�n.
Autenticaci�n y Seguridad:

Con Blazor WebAssembly, el c�digo de la aplicaci�n y cierta l�gica est� en el cliente. Aseg�rate de implementar autenticaci�n robusta (OAuth2, OpenID Connect) y proteger las APIs para que solo los usuarios autorizados puedan realizar operaciones cr�ticas.
Resumen
Para una aplicaci�n de votaci�n electoral:

Blazor WebAssembly es m�s adecuado por su mejor escalabilidad en alta concurrencia y menor carga en el servidor.
Utiliza APIs REST para operaciones est�ndar y SignalR solo para actualizaciones en tiempo real cr�ticas.
Asegura la base de datos y considera colas de mensajes para distribuir la carga de votaci�n.