﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Multi_Tracks_API.Models;

[Table("Album")]
public partial class Album
{
    [Key]
    public int albumID { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime dateCreation { get; set; }

    public int artistID { get; set; }

    [Required]
    [StringLength(255)]

    public string title { get; set; }

    [Required]
    [StringLength(500)]

    public string imageURL { get; set; }

    public int year { get; set; }
}