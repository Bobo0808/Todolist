﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class Webuser
    {
        public Webuser()
        {
            Todolist = new HashSet<Todolist>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; } 
        public string Pwd { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Todolist> Todolist { get; set; }
    }
}