const http = require("http");

class TarotApi {

    static serverTarot() {
    
            const cards = [    
            { id: 1, nombre: "El Loco", significado: "Nuevos comienzos, libertad, espontaneidad", palabraClave: "Aventura", arquetipo: "El Viajero" },
            { id: 2, nombre: "El Mago", significado: "Poder, creatividad, acción", palabraClave: "Habilidad", arquetipo: "El Creador" },
            { id: 3, nombre: "La Sacerdotisa", significado: "Intuición, sabiduría, misterio", palabraClave: "Intuición", arquetipo: "La Guardiana" },
            { id: 4, nombre: "La Emperatriz", significado: "Abundancia, fertilidad, creatividad", palabraClave: "Nutrición", arquetipo: "La Madre" },
            { id: 5, nombre: "El Emperador", significado: "Autoridad, estructura, estabilidad", palabraClave: "Control", arquetipo: "El Líder" },
            { id: 6, nombre: "El Hierofante", significado: "Tradición, guía espiritual, aprendizaje", palabraClave: "Sabiduría", arquetipo: "El Maestro" },
            { id: 7, nombre: "Los Enamorados", significado: "Amor, decisiones, armonía", palabraClave: "Relaciones", arquetipo: "El Amante" },
            { id: 8, nombre: "El Carro", significado: "Control, victoria, determinación", palabraClave: "Éxito", arquetipo: "El Guerrero" },
            { id: 9, nombre: "La Fuerza", significado: "Valor, paciencia, autocontrol", palabraClave: "Coraje", arquetipo: "El Valiente" },
            { id: 10, nombre: "El Ermitaño", significado: "Introspección, búsqueda de sabiduría, soledad", palabraClave: "Reflexión", arquetipo: "El Sabio" },
            { id: 11, nombre: "La Rueda de la Fortuna", significado: "Cambio, ciclos, destino", palabraClave: "Destino", arquetipo: "El Cambiante" },
            { id: 12, nombre: "La Justicia", significado: "Equilibrio, verdad, responsabilidad", palabraClave: "Equidad", arquetipo: "El Juez" },
            { id: 13, nombre: "El Colgado", significado: "Reflexión, sacrificio, pausa", palabraClave: "Paciencia", arquetipo: "El Sacrificado" },
            { id: 14, nombre: "La Muerte", significado: "Transformación, fin de ciclo, renovación", palabraClave: "Cambio", arquetipo: "El Transformador" },
            { id: 15, nombre: "La Templanza", significado: "Equilibrio, moderación, paciencia", palabraClave: "Moderación", arquetipo: "El Mediador" }
        ];
        

        const server = http.createServer((req, res) => {
            res.setHeader("Content-Type", "application/json");
            if (req.url === "/tarot") {
                res.write(JSON.stringify(cards));
            } else {
                res.write(JSON.stringify({ error: "Endpoint no encontrado" }));
            }
            res.end();
        });

        server.listen(3000, () => {
            console.log("API corriendo en http://localhost:3000/tarot");
        });
    }
}
TarotApi.serverTarot();



