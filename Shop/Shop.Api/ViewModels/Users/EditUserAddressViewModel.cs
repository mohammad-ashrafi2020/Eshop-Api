using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Users;

public class EditUserAddressViewModel
{
    public long Id { get; set; }
    [Required]
    public string Shire { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string PostalAddress { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Family { get; set; }

    [Required]
    public string NationalCode { get; set; }
}