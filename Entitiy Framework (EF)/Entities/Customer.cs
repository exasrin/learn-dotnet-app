using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DupperFundamental.Entitiy_Framework__EF_.Entities;

[Table(name: "m_customer")]
public class Customer
{
    [Key, Column(name: "id")]
    public Guid Id { get; set; }
    
    [Column(name: "customer_name", TypeName = "NVarchar(50)")]
    public string CustomerName { get; set; }
    
    [Column(name: "address", TypeName = "NVarchar(250)")]
    public string Address { get; set; }
    
    [Column(name: "phone_number", TypeName = "NVarchar(14)")]
    public string PhoneNumber { get; set; }
    
    [Column(name: "email", TypeName = "NVarchar(50)")]
    public string email { get; set; }
}