

namespace Functions
{
    class PhraseSelector
    {
        private static readonly Random random = new Random();

         /**
         * Devuelve una frase aleatoria asociada a una palabra clave.
         * Contiene varias categorías de frases (Aventura, Habilidad, Intuición, etc.).
         * Si la palabra clave no se encuentra, devuelve una frase por defecto.
         * 
         * @param palabraClave La categoría de frase que se desea obtener. Puede ser
         *                     "Aventura", "Habilidad", "Intuición", etc. Si no existe,
         *                     se selecciona la categoría por defecto.
         * @return Una frase aleatoria correspondiente a la categoría indicada.
         */
         
        public static string GetRandomPhrase(string palabraClave)
        {

            Dictionary<string, List<string>> phrases = new Dictionary<string, List<string>>()
            {
            { "Aventura", new List<string> {
            "hoy podrías conocer a alguien que cambiará tu día.",
            "un plan inesperado te llevará a un lugar divertido.",
            "prepárate para salir de tu rutina y descubrir algo nuevo."
            }},
            { "Habilidad", new List<string> {
            "tu talento será reconocido por alguien importante.",
            "aprovecha tu creatividad para resolver un problema hoy.",
            "te sentirás orgulloso de lo que lograrás con tus habilidades."
            }},
            { "Intuición", new List<string> {
            "confía en tu corazonada antes de tomar una decisión.",
            "alguien cercano te dará un consejo acertado, escucha tu instinto.",
            "hoy tu intuición te ayudará a evitar un problema."
            }},
            { "Nutrición", new List<string> {
            "es un buen día para cuidar tu salud y energía.",
            "dedica tiempo a ti mismo y a tu bienestar.",
            "una comida o hábito saludable traerá beneficios hoy."
            }},
            { "Control", new List<string> {
            "organiza tu día y verás cómo todo fluye mejor.",
            "mantén la calma en un momento complicado.",
            "tu capacidad de controlar la situación será clave hoy."
            }},
            { "Sabiduría", new List<string> {
            "aprenderás algo nuevo que te será muy útil.",
            "un consejo sabio cambiará tu perspectiva hoy.",
            "reflexionar te dará la respuesta que buscabas."
            }},
            { "Relaciones", new List<string> {
            "un amigo o ser querido te necesita hoy.",
            "una conversación importante mejorará tu vínculo con alguien.",
            "alguien especial podría aparecer en tu camino."
            }},
            { "Éxito", new List<string> {
            "recibirás reconocimiento por tu esfuerzo reciente.",
            "un proyecto o tarea terminará con excelentes resultados.",
            "hoy se abren nuevas oportunidades para avanzar en tus metas."
            }},
            { "Coraje", new List<string> {
            "enfrentarás un reto que te hará sentir valiente.",
            "tomar una decisión difícil traerá buenos resultados.",
            "tu determinación será admirada por quienes te rodean."
            }},
            { "Reflexión", new List<string> {
            "un momento de soledad te ayudará a tomar decisiones claras.",
            "piensa antes de actuar y evitarás un error.",
            "reflexionar sobre tu día te dará una idea importante."
            }},
            { "Destino", new List<string> {
            "un cambio inesperado te llevará por un camino interesante.",
            "algo que parecía casual podría tener un gran significado.",
            "acepta lo que llega hoy y verás cómo te beneficia."
            }},
            { "Equidad", new List<string> {
            "ser justo y honesto te traerá respeto de los demás.",
            "una situación se equilibrará a tu favor si actúas con prudencia.",
            "tomar decisiones responsables hoy te dará tranquilidad."
            }},
            { "Paciencia", new List<string> {
            "esperar un poco más te traerá una recompensa.",
            "no te apresures; las cosas importantes requieren tiempo.",
            "la paciencia te permitirá ver la situación con claridad."
            }},
            { "Cambio", new List<string> {
            "una situación que parecía fija se transformará a tu favor.",
            "algo que termina hoy dará paso a algo mejor mañana.",
            "acepta los cambios y descubrirás nuevas oportunidades."
            }},
            { "Moderación", new List<string> {
            "evita excesos y notarás cómo todo fluye mejor.",
            "tomarte las cosas con calma traerá tranquilidad a tu día.",
            "equilibrar tus acciones te permitirá lograr más sin estrés."
            }},
            { "", new List<string> {
            "el día será tranquilo, aprovecha para descansar.",
            "algo inesperado te hará sonreír hoy.",
            "una sorpresa agradable podría aparecer en tu camino."
            }}
        };

            if (!phrases.ContainsKey(palabraClave))
            {
                palabraClave = "";
            }

            List<string> meanings = phrases[palabraClave];
            return meanings[random.Next(meanings.Count)];
        }
    }

};





