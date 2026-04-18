using System;

namespace AnimeEventsWeb.Models
{
    
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
        
       
        public string Name { get; set; }
        
       
        public DateTime Date { get; set; }
        
       
        public string Description { get; set; }
        
      
        public string Location { get; set; }
        
       
        public string ImageUrl { get; set; }
        
       
        public string Category { get; set; }
        
        
        public EventState State { get; set; }
    }
}
