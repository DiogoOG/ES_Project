using System;

namespace TimeAssets
{
    public enum Weekday
    {
        Dom = 1,
        Seg,
        Ter,
        Qua,
        Qui,
        Sex,
        Sab,
    }
    
    public struct ClockTime
    {
        int _hours;
        int _minutes;

        public ClockTime(string time)
        {
            if (!(int.TryParse(time.Split(':')[0], out _hours) && int.TryParse(time.Split(':')[1], out _minutes)))
            {
                throw new ArgumentException("Formato requirido é « hh:mm »");
            }
            else if (_minutes < 0 || _minutes > 59 || _hours < 0 || _hours > 23)
            {
                throw new ArgumentException("Hora inválida");
            }
        }

        // Converte a hora para minutos

        public int ToMinutes() => _hours * 60 + _minutes;

        // Override para exibir o valor horário guardado

        public override string ToString() => $"{_hours,2:00}:{_minutes,2:00}";

        // Overload de operadores para comparações

        public static bool operator ==(ClockTime c1, ClockTime c2) => c1.Equals(c2); // c1.ToMinutes() == c2.ToMinutes(); ?

        public static bool operator !=(ClockTime c1, ClockTime c2) => !c1.Equals(c2); // c1.ToMinutes() == c2.ToMinutes(); ?

        public static bool operator >(ClockTime c1, ClockTime c2) => c1.ToMinutes() > c2.ToMinutes();

        public static bool operator <(ClockTime c1, ClockTime c2) => c1.ToMinutes() < c2.ToMinutes();

        public static bool operator >=(ClockTime c1, ClockTime c2) => c1.ToMinutes() >= c2.ToMinutes();

        public static bool operator <=(ClockTime c1, ClockTime c2) => c1.ToMinutes() <= c2.ToMinutes();

        // Override de Equals e GetHashCode por recomendação do IDE

        public override bool Equals(Object obj) {
            if ( obj == null) { return false; }
            else if ( obj.GetType().Name != this.GetType().Name ) { return false; }
            else { return ToMinutes() == ((ClockTime)obj).ToMinutes(); }
        }

        public override int GetHashCode() => ToMinutes();
    }

    public struct TimeSlot
    {
        private Weekday _weekday;
        private ClockTime _start;
        private ClockTime _end;

        public TimeSlot(int weekday, ClockTime start, ClockTime end)
        {
            _weekday = (Weekday)weekday;
            _start = start;
            _end = end;

            if ( (int)_weekday > 7 || (int)_weekday < 0 || _start >= _end) { throw new ArgumentException("Dados inválidos."); }

        }

        public TimeSlot(int weekday, string start, string end)
        {
            _weekday = (Weekday)weekday;
            _start = new ClockTime(start);
            _end = new ClockTime(end);;

            if ( (int)_weekday > 7 || (int)_weekday < 0 || _start >= _end) { throw new ArgumentException("Dados inválidos."); }

        }

        public bool OverlapsWith(TimeSlot other) => (other._weekday == _weekday) && ((other._start > _start && other._start < _end) || (other._end > _start && other._end < _end));

        public override string ToString() => $"{_start} - {_end} @ {_weekday}";
        public override int GetHashCode() => int.Parse( $"{(int)_weekday}{_start.GetHashCode()}{_end.GetHashCode()}" );
    }
}