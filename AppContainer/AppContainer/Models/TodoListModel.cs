namespace AppContainer.Models
{
    using MessagePack;
    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
    using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;


    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "En az 2 karakterden oluşmalıdır.")]

        public string? ToDoListItem { get; set; }
        public bool IsDone { get; set; }
    }


}