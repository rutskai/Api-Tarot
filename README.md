# API Tarot

Aplicación de Tarot que combina **C#** y **Node.js/Express**. Permite obtener cartas del tarot, generar predicciones personalizadas y gestionar el mazo de cartas mediante un backend en Node.js y una interfaz en C#.

---



# Herramientas necesarias para iniciar el proyecto

- **C# 12**  
- **.NET 8**  
- **.NET SDK** (ajustar según la versión instalada)
-  **Node.js** (v18 o superior recomendado, ya implementa npm)

# Instalación

  -  Clonar el repositorio o descargarlo
  -  Abrir entorno de desarrollo (Recomendado -> Visual Studio Code)
  -  Abrir terminal en el proyecto y ejecutar los comandos:
      - npm install
      - dotnet restore
      - dotnet run
   
# Ejemplo de salida del programa
<img width="801" height="105" alt="image" src="https://github.com/user-attachments/assets/00f4efa3-f081-45a9-a1f5-91d6876b776b" />


<img width="801" height="205" alt="image" src="https://github.com/user-attachments/assets/7e8d6220-5704-4a7c-be80-a1a82d428a01" />




---

# Endpoints de la API (Express)

| Método | Ruta                | Descripción                                                                                                   |
| ------ | ------------------- | ------------------------------------------------------------------------------------------------------------- |
| GET    | `/tarot`            | Devuelve todas las cartas disponibles.                                                                        |
| GET    | `/tarot/random`     | Devuelve una carta aleatoria y la marca como utilizada.                                                       |
| GET    | `/tarot/utilizadas` | Devuelve todas las cartas que ya fueron utilizadas.                                                           |
| PUT    | `/tarot/update`     | Actualiza los datos de una carta específica. JSON: `{ id, nombre?, significado?, palabraClave?, arquetipo? }` |
| GET    | `/tarot/reset`      | Resetea todas las cartas a su estado inicial (`No utilizada`).                                                |

- **IMPORTANTE**: El endpoint tarot/update/ se encuentra en UpdateCard.cs, es una gestión interna, si se quiere actualizar alguna carta hay que ejecutar este archivo en específico.
- **Ejecución**: dotnet run

# Json tarot.json
El archivo tarot.json contiene la información de todas las cartas del tarot utilizada por el servidor Node.js/Express. 
Sirve para informar sobre los datos que se manejan y cómo se utilizan.
Cada carta tiene las siguientes propiedades:

- id: Identificador único de la carta.
- nombre: Nombre de la carta.
- significado: Significado de la carta.
- palabraClave: Palabra clave asociada (ej. "Aventura", "Habilidad").
- arquetipo: Tipo o rol de la carta.
- estado: "No utilizada" o "Utilizada" según si la carta ya fue seleccionada en una tirada.
  
1. Al iniciar Tarotapi.js, se crea o reinicia tarot.json con todas las cartas en estado "No utilizada".
2. Al resetear las cartas con ResetDeck.ResetDeckApi(), cambia el estado de todas las cartas a "No utilizada" y se guarda en el JSON.
3. Se selecciona una carta aleatoria en GetSelectionCardAsync() y marca la carta seleccionada como "Utilizada" y actualiza el JSON.
4. El endpoint /tarot/utilizadas sirve para informar sobre el estado de las cartas, se puede hacer así o consultando el JSON.
  

# Funciones

**Flujo Principal**

1. Inicia el servidor Node.js (Tarotapi.js).

2. Espera 2 segundos para asegurar que el servidor esté listo.

3. Resetea el mazo de cartas vía ResetDeck.ResetDeckApi().

4. Inicia el menú principal con Menu.GetMenu().

5. Captura y muestra errores en consola.

---

**GetMenu**

1. Si no se ha proporcionado un nombre, solicita el nombre del usuario y valida con GeneralValidation.IsValid().

2. Carga todas las cartas con GetApi.GetApiTarot().

3. Inicia la tirada de cartas al presionar Enter y obtiene la carta seleccionada con SelectionCard.GetSelectionCardAsync().

4. Muestra:

  - Carta seleccionada

  - Significado

  - Arquetipo

  - Predicción generada por GeneratePrediction.

5. Pregunta si desea realizar otra tirada (s/n), validando la opción con ValidationOptions.IsValidOption().

6. Repite el flujo hasta que el usuario decida salir.

- Retorna: Task (ejecución asincrónica).

- Ejemplo de Salida:

<img width="518" height="127" alt="image" src="https://github.com/user-attachments/assets/28770b8e-73bf-430b-86e2-bd6bf0efd6df" />

---


**GetPrediction**

1. Valida que la lista de cartas y la carta seleccionada no sean nulas o vacías mediante GeneralValidation.IsValid().

2. Selecciona aleatoriamente una frase de inicio, otra de medio y finalmente una frase asociada a la palabra clave de la carta con PhraseSelector.GetRandomPhrase().

3. Concadena los textos en un mensaje completo de predicción.

- Retorna: string con la predicción completa.

- Ejemplo de salida:

<img width="1038" height="70" alt="image" src="https://github.com/user-attachments/assets/54d917a6-88dc-44be-965b-cc15e26b5745" />

---

**GetApiTarot**

1. Realiza una petición HTTP GET a http://localhost:3000/tarot.

2. Deserializa la respuesta JSON a una lista de objetos Card.

3. Valida la lista mediante GeneralValidation.IsValid(List<Card>).

- Retorna: List<Card> con las cartas.
- Comportamiento de errores: Retorna lista vacía si falla la petición o si los datos son inválidos.

---

**GetRandomPhrase**

- Contiene un diccionario de categorías (ej. "Aventura", "Habilidad", "Intuición", etc.)

- Selecciona aleatoriamente una frase dentro de la categoría correspondiente.

- Si no encuentra la palabra clave, devuelve una frase por defecto.

  **ResetDeckApi**

- Hace una petición GET al endpoint /tarot/reset.

- Si la respuesta es exitosa, imprime en consola que el mazo se reseteó correctamente.

- Si falla, muestra el error en consola.

---

**GetSelectionCardAsync**

- Hace petición HTTP GET al endpoint /tarot/random.

- Deserializa la respuesta a RandomCardResponse.

- Retorna la carta seleccionada (Card).

- Comportamiento de errores: Si no se obtiene carta, devuelve un objeto Card vacío.

# Validaciones detalladas

**CheckName**

- Valida que un nombre contenga solo letras y no sea vacío.

- Explicación: Utiliza expresiones regulares para permitir únicamente letras [a-zA-Z].

---

**IsValidOption**

Valida opciones ingresadas en el menú: "s" o "n".

Proceso:

  - Convierte la entrada a minúsculas y elimina espacios.

  - Verifica que sea un nombre válido (CheckName).

Si no es "s" o "n", solicita nueva entrada hasta que sea válida.

---

**IsValid(string name)**

Valida nombres ingresados por consola.

- Elimina espacios al inicio y final.

- Verifica que cumpla reglas de CheckName.

Si no es válido, solicita ingresar nuevamente.

**IsValid(List<Card> cards)**

Valida que la lista de cartas no esté vacía ni sea nula.

**IsValid(Card card)**

Valida que los campos esenciales de una carta (Nombre, PalabraClave, Arquetipo) no sean nulos.

---

# Autora

- Ruth Collado García








