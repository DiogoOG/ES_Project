using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    // Mediator class! It mediates the interactions between all the entities involved
    public class Prescription
    {
        private IPrescriptionable _prescriptionable;    // What
        private DateTime _schedule;                     // When
        private User[] _users;                          // Who
        private bool _public;                           // Is it public?
        private List<User> _permissions;                // List of those that have access permissions (if private)

        public IPrescriptionable Prescriptionable { get => _prescriptionable; set => _prescriptionable = value; }
        public DateTime Schedule { get => _schedule; set => Schedule = value; }

        public Patient Patient { get => (Patient)_users[0]; set => _users[0] = value; }
        public Therapist Therapist { get => (Therapist)_users[1]; set => _users[1] = value; }

        public bool Visibility { set => _public = value; }

        public bool HasPermission(User user) => _public || _permissions.Contains(user);
        public void AddPermission(User user) => _permissions.Add(user);
        public void RevokePermission(User user) => _permissions.Remove(user);

        public override string ToString() => $"P: {Patient} T: {Therapist} => {Prescriptionable.Name} @ {Schedule}" ;
    }
}
