using System;

namespace AnimeEventsWeb.Models
{
    // C# Enum para manejar los diferentes estados del evento, tal como se solicitó.
    public enum EventState
    {
        Activo,
        Inactivo,
        Cancelado,
        Finalizado
    }

    public class Event
    {
        public int Id { get; set; }
        
        // Nombre principal del evento (Ej: Tokyo Fest 2026)
        public string Name { get; set; }
        
        // Fecha de realización
        public DateTime Date { get; set; }
        
        // Breve resumen o descripción
        public string Description { get; set; }
        
        // Lugar físico o virtual
        public string Location { get; set; }
        
        // URL para mostrar una imagen estilo banner/poster en las cards
        public string ImageUrl { get; set; }
        
        // Categoría (Ej: Anime, Cosplay, K-Pop, Gaming)
        public string Category { get; set; }
        
        // Estado actual del evento, fundamental para el feedback visual
        public EventState State { get; set; }
    }
}
