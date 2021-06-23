using Clinic;
using System;
using System.IO;
using System.Windows.Forms;

namespace ClinicInterface
{
    class Program
    {

        private static string _dataPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Clinic\\Data";
        public static string DataPath { get => _dataPath; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// [STAThread]
        static void Main(string[] args)
        {
            Console.Write(DataPath);

            string patientsFilename = $"{DataPath}\\patients.txt";
            PatientsRepository patientsRepository = new PatientsRepository(patientsFilename);

            string therapistsFilename = $"{DataPath}\\therapists.txt";
            TherapistsRepository therapistsRepository = new TherapistsRepository(therapistsFilename);

            string prescriptionsFilename = $"{DataPath}\\prescriptions.txt";
            PrescriptionsRepository prescriptionsRepository = new PrescriptionsRepository(prescriptionsFilename);

            string sessionsFilename = $"{DataPath}\\sessions.txt";
            SessionsRepository sessionsRepository = new SessionsRepository(sessionsFilename);

            Controller.Instance = new Controller(patientsRepository, therapistsRepository, prescriptionsRepository,sessionsRepository);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

        }
    }
}