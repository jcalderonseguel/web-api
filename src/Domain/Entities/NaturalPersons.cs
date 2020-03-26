using System;

namespace Domain.Entities
{
    public partial class NaturalPersons
    {
        public Guid Person { get; set; }
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int Gender { get; set; }
        public int? MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string Alias { get; set; }

        public virtual Genders GenderNavigation { get; set; }
        public virtual MaritalStatus MaritalStatusNavigation { get; set; }
        public virtual Countries NationalityNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
    }
}