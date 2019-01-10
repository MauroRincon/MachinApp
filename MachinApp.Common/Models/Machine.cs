namespace MachinApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        public string Modelo { get; set; }

        public int Terminal { get; set; }

        public object Archivo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
