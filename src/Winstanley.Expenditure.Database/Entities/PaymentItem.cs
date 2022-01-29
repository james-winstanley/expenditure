using System.ComponentModel.DataAnnotations.Schema;

namespace Winstanley.Expenditure.Database.Entities;

public record PaymentItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int SortOrder { get; set; }
    public int GroupId { get; set; }
    public int PaymentFrequencyId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public Group Group { get; }

    [ForeignKey(nameof(PaymentFrequencyId))]
    public PaymentFrequency PaymentFrequency { get; }
}