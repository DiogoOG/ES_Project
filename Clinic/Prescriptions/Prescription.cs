using Clinic.Users;
using Clinic.Utils;
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
        private bool _public;
        private State currentState;     // Is it public?
        private List<User> _permissions;                // List of those that have access permissions (if private)

        public IPrescriptionable Prescriptionable { get => _prescriptionable; set => _prescriptionable = value; }
        public DateTime Schedule { get => _schedule; set => _schedule = value; }

        public int IdPatient { get => _idPatient; set => _idPatient = value; }
        public int IdTherapist { get => _idTherapist; set => _idTherapist = value; }

        public bool Visibility { get => _public;  set => _public = value; }

        public void setState(State newState)
        {
            currentState = newState;
            if (currentState.ToString() == "Clinic.Utils.Private")
                _public = false;
            else _public = true;
        }

        public void pushButton()
        {
            currentState.pushButton(this);
        }

        public bool HasPermission(User user) => _public || _permissions.Contains(user);
        public void AddPermission(User user) => _permissions.Add(user);
        public void RevokePermission(User user) => _permissions.Remove(user);

        public override string ToString() {
            return $"{IdPatient},{IdTherapist},{Prescriptionable.Type},{Prescriptionable.Name},{Visibility},{Schedule}";
        }
    }
}
