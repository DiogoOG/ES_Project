using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    // Mediator class! It mediates the interactions between all the entities involved
    public class Prescription : Entity<int>
    {
        private int _idPatient;                         // Who
        private int _idTherapist;                       // Who
        private IPrescriptionable _prescriptionable;    // What
        private DateTime _schedule;                     // When
        private bool _public;                           // Is it public?
        private List<int> _permissions;                 // List of those that have access permissions (if private)

        public IPrescriptionable Prescriptionable { get => _prescriptionable; set => _prescriptionable = value; }
        public DateTime Schedule { get => _schedule; set => _schedule = value; }

        public int IDPatient { get => _idPatient; set => _idPatient = value; }
        public int IDTherapist { get => _idTherapist; set => _idTherapist = value; }

        public bool Visibility { get => _public;  set => _public = value; }

        public bool HasPermission(int idUser) => _public || (idUser==IDTherapist) || (idUser==IDPatient) || _permissions.Contains(idUser);
        public void RevokePermission(int idUser) => _permissions.Remove(idUser);

        public override string ToString() => $"{IDPatient},{IDTherapist},{Prescriptionable.Type},{Prescriptionable.Name},{Visibility},{Schedule}";
    }
}
