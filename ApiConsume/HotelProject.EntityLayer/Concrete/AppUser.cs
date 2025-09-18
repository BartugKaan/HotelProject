using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace HotelProject.EntityLayer.Concrete;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string City { get; set; } = default!;
    public string FullName => string.Join(" ", Name, Surname);
}
