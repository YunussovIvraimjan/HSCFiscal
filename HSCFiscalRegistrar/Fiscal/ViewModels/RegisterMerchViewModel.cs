﻿using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Fiscal.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumberUser { get; set; }
        
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "ИИН")]
        public string IIN { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Наименование компании")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Юридический адрес")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Налоговый режим")]
        public TaxationTypeEnum TaxationType { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Плательщик НДС")]
        public bool VAT { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Серия НДС")]
        public string VATSeria { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Номер НДС")]
        public string VATNumber { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
 
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}