const express = require("express");
const fs = require("fs");
const bodyParser = require("body-parser");

const app = express();
app.use(bodyParser.json());

const FILE_PATH = "tarot.json";

class TarotApi {

  /**
   * API de Tarot
   *
   * Este servidor Express proporciona endpoints para trabajar con cartas del tarot.
   * Permite:
   *  - Obtener todas las cartas disponibles (/tarot)
   *  - Obtener una carta aleatoria y marcarla como utilizada (/tarot/random)
   *  - Obtener todas las cartas que ya fueron utilizadas (/tarot/utilizadas)
   *  - Actualizar información de una carta específica (/tarot/update)
   *  - Reiniciar todas las cartas a su estado inicial (/tarot/reset)
   *
   * Los datos se almacenan en memoria y se guardan en el archivo "tarot.json",
   * incluyendo el estado de cada carta ("utilizada").
   * La API corre en http://localhost:3000/tarot
   */

  static loadCards() {
    const cards = [
      {
        id: 1,
        nombre: "El Loco",
        significado: "Nuevos comienzos, libertad, espontaneidad",
        palabraClave: "Aventura",
        arquetipo: "El Viajero",
      },
      {
        id: 2,
        nombre: "El Mago",
        significado: "Poder, creatividad, acción",
        palabraClave: "Habilidad",
        arquetipo: "El Creador",
      },
      {
        id: 3,
        nombre: "La Sacerdotisa",
        significado: "Intuición, sabiduría, misterio",
        palabraClave: "Intuición",
        arquetipo: "La Guardiana",
      },
      {
        id: 4,
        nombre: "La Emperatriz",
        significado: "Abundancia, fertilidad, creatividad",
        palabraClave: "Nutrición",
        arquetipo: "La Madre",
      },
      {
        id: 5,
        nombre: "El Emperador",
        significado: "Autoridad, estructura, estabilidad",
        palabraClave: "Control",
        arquetipo: "El Líder",
      },
      {
        id: 6,
        nombre: "El Hierofante",
        significado: "Tradición, guía espiritual, aprendizaje",
        palabraClave: "Sabiduría",
        arquetipo: "El Maestro",
      },
      {
        id: 7,
        nombre: "Los Enamorados",
        significado: "Amor, decisiones, armonía",
        palabraClave: "Relaciones",
        arquetipo: "El Amante",
      },
      {
        id: 8,
        nombre: "El Carro",
        significado: "Control, victoria, determinación",
        palabraClave: "Éxito",
        arquetipo: "El Guerrero",
      },
      {
        id: 9,
        nombre: "La Fuerza",
        significado: "Valor, paciencia, autocontrol",
        palabraClave: "Coraje",
        arquetipo: "El Valiente",
      },
      {
        id: 10,
        nombre: "El Ermitaño",
        significado: "Introspección, búsqueda de sabiduría, soledad",
        palabraClave: "Reflexión",
        arquetipo: "El Sabio",
      },
      {
        id: 11,
        nombre: "La Rueda de la Fortuna",
        significado: "Cambio, ciclos, destino",
        palabraClave: "Destino",
        arquetipo: "El Cambiante",
      },
      {
        id: 12,
        nombre: "La Justicia",
        significado: "Equilibrio, verdad, responsabilidad",
        palabraClave: "Equidad",
        arquetipo: "El Juez",
      },
      {
        id: 13,
        nombre: "El Colgado",
        significado: "Reflexión, sacrificio, pausa",
        palabraClave: "Paciencia",
        arquetipo: "El Sacrificado",
      },
      {
        id: 14,
        nombre: "La Muerte",
        significado: "Transformación, fin de ciclo, renovación",
        palabraClave: "Cambio",
        arquetipo: "El Transformador",
      },
      {
        id: 15,
        nombre: "La Templanza",
        significado: "Equilibrio, moderación, paciencia",
        palabraClave: "Moderación",
        arquetipo: "El Mediador",
      },
    ];

    return cards;
  }
   
}



fs.writeFileSync(FILE_PATH, JSON.stringify(TarotApi.loadCards(), null, 2), "utf-8");
let cards = JSON.parse(fs.readFileSync(FILE_PATH, "utf-8"));


app.get("/tarot/reset", (req, res) => {

  cards = TarotApi.loadCards().map(c => ({
    ...c,
    estado: "No utilizada"  
  }));

  fs.writeFileSync(FILE_PATH, JSON.stringify(cards, null, 2), "utf-8");

  res.json({ mensaje: "Cartas reseteadas", cards });
});

app.get("/tarot", (req, res) => {
  res.json(cards);
});


app.get("/tarot/random", (req, res) => {
  if (cards.length === 0) {
    return res.status(404).json({ error: "No hay cartas disponibles" });
  }

  const randomIndex = Math.floor(Math.random() * cards.length);
  cards[randomIndex].estado = "Utilizada";

  fs.writeFileSync(FILE_PATH, JSON.stringify(cards, null, 2), "utf-8");
  res.json({ CardSelected: cards[randomIndex] });
  
});

app.get("/tarot/utilizadas", (req, res) => {
  if (cards.length === 0) {
    return res.status(404).json({ error: "No hay cartas disponibles" });
  }

  const utilizadas = cards.filter((card) => card.estado === "Utilizada");

  res.json(utilizadas);
});

app.put("/tarot/update", (req, res) => {
  const data = req.body;
  const card = cards.find((c) => c.id === data.id);
  if (!card) return res.status(404).json({ error: "Carta no encontrada" });

  const validFields = ["nombre", "significado", "palabraClave", "arquetipo"];
  validFields.forEach((field) => {
    if (data[field]) card[field] = data[field];
  });

  fs.writeFileSync(FILE_PATH, JSON.stringify(cards, null, 2), "utf-8");

  res.json({ mensaje: "Carta actualizada", actualizado: card });
});

app.listen(3000, () => {
  console.log(`API de Tarot corriendo en http://localhost:3000/tarot`);
});
