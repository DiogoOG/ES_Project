using System;
using System.IO;
using System.Windows.Forms;
using Clinic.Repository;

namespace ClinicInterface
{
    class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// [STAThread]
        static void Main(string[] args)
        {
            string patientsFilename = "C:\\Users\\Install\\Source\\Repos\\ES_Project\\Clinic\\Data\\patients.txt";
            PatientsRepository patientsRepository = new PatientsRepository(patientsFilename);

            string therapistsFilename = "C:\\Users\\Install\\Source\\Repos\\ES_Project\\Clinic\\Data\\therapists.txt";
            TherapistsRepository therapistsRepository = new TherapistsRepository(therapistsFilename);
            
            Controller controller = new Controller(patientsRepository, therapistsRepository);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin(controller));

            
        }
    }
}
