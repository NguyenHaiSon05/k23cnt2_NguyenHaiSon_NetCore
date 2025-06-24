using System;
using System.Collections.Generic;

namespace NhsLesson10DB.Models;

public partial class Category
{
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public bool? CateStatus { get; set; }
}
