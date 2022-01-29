using System.ComponentModel.DataAnnotations.Schema;

namespace Winstanley.Expenditure.Database.Entities;

public record PaymentItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateOnly DueDate { get; set; }
    public int SortOrder { get; set; }
    public int? PersonId { get; set; }
    public int GroupId { get; set; }
    public int PaymentFrequencyId { get; set; }


    /// <summary>
    /// Gets the person.
    /// A payment item can belong to a person.
    /// If not assigned to a person, this payment item belongs to the household.
    /// </summary>
    /// <value> The person. </value>
    [ForeignKey(nameof(PersonId))]
    public Person? Person { get; }


    /// <summary>
    /// Gets the group.
    /// All payment items belong to a group.
    /// </summary>
    /// <value> The group. </value>
    [ForeignKey(nameof(GroupId))]
    public Group Group { get; }


    /// <summary>
    /// Gets the payment frequency.
    /// By default, most payments are given a monthly payment frequency.
    /// </summary>
    /// <value> The payment frequency. </value>
    [ForeignKey(nameof(PaymentFrequencyId))]
    public PaymentFrequency PaymentFrequency { get; }
}