using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MusicReviewAPI.Models;

public class User : IdentityUser
{
    public string UserName { get; set; } 
    public ICollection<Review>? Reviews { get; set; }
}