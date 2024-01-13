using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DupperFundamental.Entitiy_Framework__EF_.Entities;

[Table(name: "t_purchase")]
public class Purchase
{
    [Key, Column(name:"id")]
    public Guid Id { get; set; }
    
    [Column(name: "trans_date")]
    public DateTime TrancDate { get; set; }
    
    [Column(name: "customer_id")]
    public Guid CustomerId { get; set; }        // foregin key
    
    // virtual menandakan bahwa adanya relasi
    public virtual Customer Customer{ get; set; }                               // object menandakan adanya relasi one to many atau one to one
    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }    // collection menandakan adanya relasi many to one
}