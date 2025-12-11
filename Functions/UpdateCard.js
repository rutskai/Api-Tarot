/**
 * Actualiza la información de una carta del tarot en el servidor.
 *
 * Esta función realiza una petición HTTP PUT al endpoint /tarot/update
 * enviando el objeto `card` como cuerpo de la solicitud en formato JSON.
 * Luego espera la respuesta del servidor y la imprime en consola.
 *
 * @async
 * @function updateCard
 * @throws {Error} Lanza un error si la petición falla.
 * @example
 * const card = { id: 3, significado: "Intuición y sabiduría" };
 * updateCard();
 */

const card = {
  id: 3, 
  significado: "Intuición y sabiduría"
};

async function updateCard() {
  try {
    const res = await fetch("http://localhost:3000/tarot/update", {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(card)
    });

    const json = await res.json();
    console.log("Respuesta del servidor:", json);
  } catch (error) {
    console.log("Error actualizando la carta:", error);
  }
}

updateCard();


