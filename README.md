# Proyecto Final de Programación del Curso de Interacción Humano Computados 2020-01
## Fabrizio Flores - Bryan Masca
Inspirados en las series animadas que vimos en nuestra infancia escogimos BeyBlade como idea principal para nuestro juego, manteniendo la temática clásica de la serie sobre peleas de tropos en áreas, cada jugador podrá escoger entre 4 modelos de trompos, luego tendrán que posicionar el estadio según su comodidad para iniciar la batalla contra otros zombies.

El juego se compone de dos partes que se enmarcan en los conceptos del curso.
* Realidad Aumentada: Considerando que se va ejecutar sobre una plataforma móvil, los kits de desarrollo que se utilizaron son: AR Foundation, ARcore. 
* Red y Conectividad: Se optó por utilizar Photon 2.
* Además se considera que el juego contiene entorno 2D y 3D.

El juego tiene la opción de poder enfrentarse en equipo con otra persona a una horda de zombies en un estadio donde los trompos que ellos seleccionen batallarán, para el movimiento de los jugadores se usaron assets disponibles en unity store que nos proporcionaron joysticks virtuales para poder manejar el movimiento de los trompos, para la conexión online entre jugadores en la opción versus o colaborativa se usó Photon 2, este framework nos permite el desarrollo de juego multijugador proporcionando soporte para realizar un matchmaking o funciones como RPC que se utilizan intercambiar datos entre los jugadores.

Además, al aplicativo se le sumó Realidad Aumentada utilizando la herramienta AR Core proporcionada por Google para trabajar en dispositivos Androids, utilizándose para poder virtualmente establecer sobre una superficie el estadio de batalla.

## Instrucciones de Instalacion y Uso
- Descargar todo el repositorio.
- Instalar UnityHub, Unity version 2019.3 con soporte para Android y opcionalmente para IOS.
- Cargar la carpeta descargada con UnityHUb
- Asignar la version a el proyecto cargado y abrirlo
- Dentro de Unity en las opciones de archivo buscar la que diga Build Settings
- Cambiar la plataforma segun conveniencia y ejecutar Build
- Una vez generado el apk este tiene que ser instalado en el dispositivo de preferencia (tener en cuenta que no todos los dispositivos Android tienen compativilidad con ARCore, consultar https://developers.google.com/ar/discover/supported-devices)
- Ya instalado, lo unico que queda es JUGAR !!!

### El link del video demo: https://drive.google.com/drive/folders/1HLOeW96to7548MwwdwmrMkJxXPpHNqQU?usp=sharing

Agradecimiento especial a Alonso Valdivia(Adriana618-Love) por ayudarnos a realizar las pruebas
