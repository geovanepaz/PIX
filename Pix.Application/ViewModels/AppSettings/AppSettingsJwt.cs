namespace Pix.Application.ViewModels.AppSettings
{
    public class AppSettingsJwt
    {
        public string Secret { get; set; }
        public int ExpiracaoSegundos { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
