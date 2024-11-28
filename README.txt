https://www.youtube.com/watch?v=EmV_IBYIlyo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=5
https://drive.google.com/file/d/1EbYYjY7ubkpVKgBVE3Dloa9tr-oqo58g/view
________________________________________tutorial api aspnet + diagram pokemon_______________________
https://www.youtube.com/watch?v=NYpOaPC6jrg
________________explicacion de [fromquery]/[frombody etc]_________

----------------->EN LA CLASS POKEMON HAY EXPLICACIONES EN EL POKEOMON todos los files.<-----------------

·CREO LOS MODELS, EL DATACONTEXT..

·DB: Creo una DB con el SSMS...
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
        //Después de esto el comando para actualizar la Database es:
        //EntityFrameworkCore\Update-DataBase

--->((Para que el paso 7 funcione bine necesito las relaciones bien especificadas))<---


·CREO LAS INTERFACES, RESPOSITORY, DTO, HELPER..

(para implementar SignalR, creamos una carpeta hub y dentro puede ser u metodo vacio por ejemplo ya que en
el controller es donde pondremos la Interface de Hub (IHub) para poder luego desde el front esucharlo)
_________________________________________________________
Recomendación para el Proyecto Electoral
Dado que se espera una alta concurrencia en un entorno electoral, Blazor WebAssembly es probablemente la opción más adecuada por las siguientes razones:

Reducción de carga en el servidor: La aplicación WebAssembly ejecuta la mayoría de la lógica de negocio en el cliente, reduciendo las conexiones activas en el servidor y, por tanto, la posibilidad de colapsos bajo alta concurrencia.

Escalabilidad: WebAssembly permite un número mucho mayor de usuarios concurrentes, ya que la carga del servidor se limita a las operaciones de API (como el envío de votos y la recuperación de resultados), en lugar de mantener una conexión abierta para cada usuario.

Descentralización del procesamiento: Con WebAssembly, el navegador del usuario realiza el procesamiento de la interfaz, mientras que el servidor solo se encarga de las operaciones de API. Esto ayuda a evitar cuellos de botella en el servidor.

Implementación y Gestión de las Votaciones
API Rest o SignalR para eventos importantes:

API Rest: Puedes usar API REST para operaciones CRUD (como envío de votos y recuperación de resultados).
SignalR en WebAssembly: Aunque Blazor WebAssembly no mantiene conexiones persistentes, puedes implementar SignalR en el servidor para eventos críticos (como actualización en tiempo real de resultados) sin la carga constante que tendría en Blazor Server.
Escalabilidad de Base de Datos:

Es crucial que la base de datos esté optimizada para manejar escrituras rápidas y múltiples conexiones. Considera usar bases de datos en la nube que ofrezcan escalabilidad automática, como Azure Cosmos DB, Amazon DynamoDB, o una base de datos SQL con capacidad de escalado horizontal.
Colas de Mensajes (Message Queues):

Para manejar altas cargas de votación en tiempo real, podrías implementar colas de mensajes (como Azure Queue Storage, Amazon SQS, o RabbitMQ) para distribuir las operaciones de escritura. Cada voto se agrega a la cola y luego se procesa de forma asíncrona, evitando una sobrecarga directa en la base de datos.
Balanceo de Carga y CDN:

Utilizar un CDN (Content Delivery Network) para servir los recursos estáticos de la aplicación WebAssembly y un balanceador de carga para distribuir el tráfico entre múltiples instancias del backend puede mejorar la resiliencia y velocidad de la aplicación.
Autenticación y Seguridad:

Con Blazor WebAssembly, el código de la aplicación y cierta lógica está en el cliente. Asegúrate de implementar autenticación robusta (OAuth2, OpenID Connect) y proteger las APIs para que solo los usuarios autorizados puedan realizar operaciones críticas.
Resumen
Para una aplicación de votación electoral:

Blazor WebAssembly es más adecuado por su mejor escalabilidad en alta concurrencia y menor carga en el servidor.
Utiliza APIs REST para operaciones estándar y SignalR solo para actualizaciones en tiempo real críticas.
Asegura la base de datos y considera colas de mensajes para distribuir la carga de votación.