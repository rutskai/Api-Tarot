
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


