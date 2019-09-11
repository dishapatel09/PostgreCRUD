using System.ComponentModel.DataAnnotations;


namespace PostgreCRUD.Web.Models
{
    public class User : BaseEntity
    {
        [Key]
        public long Id
        {
            get;
            set;
        }

        [Required]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        public string LastName
        {
            get;
            set;
        }
        [Required]
        public string Email
        {
            get;
            set;
        }

    }  
}
