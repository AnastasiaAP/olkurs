using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Operation
    {
        public Operation() : this(id: 0, firstEvent: 0, secondEvent: 0,duration: 0) { }

        public Operation(int id, int firstEvent, int secondEvent,int duration)
        {
            Id = id;
            FirstEvent = firstEvent;
            SecondEvent = secondEvent;
            Duration = duration;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Початкова подія необхідна")]
        public int FirstEvent { get; set; }
        [Required(ErrorMessage = "Кінцева подія необхідна")]
        public int SecondEvent { get; set; }
        [Required(ErrorMessage = "Тривалість необхідна до введення")]
        public int Duration { get; set; }

    }
}