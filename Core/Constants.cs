namespace BenariMikronWebApp.Core
{
    public static class Constants
    {
        public static class Roles
        {
            //Set Role Pengguna Awal
            public const string Administrator = "Administrator";
            public const string SuperAdmin = "SuperAdmin";
            public const string User = "User";

            //Set Role Pendaftaran Pasien
            public const string PendaftaranPasien = "PendaftaranPasien";
            public const string PasienBaru = "PasienBaru";
            public const string TambahPasienBaru = "TambahPasienBaru";
            public const string PasienLuar = "PasienLuar";
            public const string PasienBayi = "PasienBayi";
        }

        //public static class Policies 
        //{
        //    public const string RequireAdmin = "RequireAdmin";
        //    public const string RequireManager = "RequireManager";
        //}
    }
}
