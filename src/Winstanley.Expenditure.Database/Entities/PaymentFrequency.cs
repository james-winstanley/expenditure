namespace Winstanley.Expenditure.Database.Entities;

public record PaymentFrequency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SortOrder { get; set; }
}