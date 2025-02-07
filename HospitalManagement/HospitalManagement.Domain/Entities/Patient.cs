using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s]+$", ErrorMessage = "Имя должно содержать только буквы")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Фамилия обязательна")]
        [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Пол обязателен")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Номер страхового полиса обязателен")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Номер страхового полиса должен содержать только цифры")]
        public string InsurancePolicyNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефон обязателен")]
        [RegularExpression(@"^\+?\d{0,15}$", ErrorMessage = "Телефон должен содержать только цифры и '+' в начале")]
        public string TelephoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Электронный адрес обязателен")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string? EmailAddress { get; set; }


        public int WorkplaceId { get; set; }  
        public Workplace? Workplace { get; set; }

        [Required(ErrorMessage = "Адрес обязателен")]
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public MedicalCard? MedicalCard { get; set; }

        [Required(ErrorMessage = "Паспортные данные обязательны")]
        [RegularExpression(@"^\d{4}\s\d{6}$", ErrorMessage = "Паспорт должен быть в формате '1234 567890'")]
        public Passport? Passport { get; set; }
        public ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
    }
}
