﻿namespace Winstanley.Expenditure.Database.Entities;

public record Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortOrder { get; set; }
}