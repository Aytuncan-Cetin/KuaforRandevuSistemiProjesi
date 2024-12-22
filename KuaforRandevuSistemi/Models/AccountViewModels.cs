using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Ad alanı gereklidir.")]
    public string Ad { get; set; }

    [Required(ErrorMessage = "Soyad alanı gereklidir.")]
    public string Soyad { get; set; }

    [Required(ErrorMessage = "Telefon alanı gereklidir.")]
    [Phone(ErrorMessage = "Geçersiz telefon numarası.")]
    public string Telefon { get; set; }

    [Required(ErrorMessage = "Email alanı gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı gereklidir.")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Şifreyi Onayla")]
    [Compare("Password", ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
    public string ConfirmPassword { get; set; }
}

public class LoginViewModel
{
    [Required(ErrorMessage = "Email alanı gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı gereklidir.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Beni Hatırla?")]
    public bool RememberMe { get; set; }
}

public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "Email alanı gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı gereklidir.")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Şifreyi Onayla")]
    [Compare("Password", ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
    public string ConfirmPassword { get; set; }

    public string Code { get; set; }
}

public class ForgotPasswordViewModel
{
    [Required(ErrorMessage = "Email alanı gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
    public string Email { get; set; }
}
