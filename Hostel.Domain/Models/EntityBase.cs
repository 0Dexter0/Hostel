﻿using System.ComponentModel.DataAnnotations;

namespace Hostel.Domain.Models;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}