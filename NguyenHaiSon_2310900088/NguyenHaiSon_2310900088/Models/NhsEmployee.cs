using System;
using System.Collections.Generic;

namespace NguyenHaiSon_2310900088.Models;

public partial class NhsEmployee
{
    public int NhsEmpId { get; set; }

    public string? NhsEmpName { get; set; }

    public string? NhsEmpLevel { get; set; }

    public DateOnly? NhsEmpStartDate { get; set; }

    public bool? NhsEmpStatus { get; set; }
}
