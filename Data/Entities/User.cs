using System.ComponentModel.DataAnnotations;

namespace Findry.Data.Entities
{


    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }   // Store hashed password

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        // Many-to-Many relationship with Role
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }  // e.g., "Admin", "Customer", "Seller"

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    // Join table for User and Role many-to-many relationship
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

}
