        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

namespace SequenceLib
{
    public class Sequence : Entity, ISequence

    {
        UserContext _context;

        public string Prefix { get; set; }
        public string PrefYear { get; set; }
        public int Num { get; set; }

        public Sequence()
        {
            _context = new UserContext();
        }

        public Sequence(string Name)
        {
            this.Name = Name;
            Num = 0;
            _context = new UserContext();
        }
        public Sequence(string Name, string Pref)
        {
            this.Name = Name;
            Prefix = Pref;
            Num = 0;
            _context = new UserContext();
        }
        public Sequence(string Name, string Pref, string PrefY)
        {
            this.Name = Name;
            Prefix = Pref;
            PrefYear = PrefY;
            Num = 0;
            _context = new UserContext();
        }

        public Sequence GetCurrent()
        {
            if (_context.Sequences == null || Name == null)
            {
                throw new InvalidOperationException("Сначала нужно загрузить нумератор при помощи метода Load");
            }

            return _context.Sequences.Where(s=>s.Name == this.Name && s.Num==_context.Sequences.Max(m => m.Num)).FirstOrDefault ();

        }

        public bool Load(string Name)
        {
            ISequence sq = new Sequence();
            try
            {
                sq = _context.Sequences.Where(s => s.Name == Name).FirstOrDefault();
                if (sq != null)
                {
                    return (true);
                }
                else
                {
                    _context.Sequences.Add(new Sequence(Name));
                    _context.SaveChanges();
                    return (true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Не могу загрузить последовательность с именем \"" + Name + "\"",ex);
            }

        }

        public string NextValue()
        {
            if (_context.Sequences == null)
            {
                throw new InvalidOperationException("Сначала нужно загрузить нумератор при помощи метода Load");
            }
            _context.Sequences.Add(new Sequence(Name));
            _context.SaveChanges();
            return _context.Sequences.Max(s => s.Num).ToString();
        }

        public override string ToString()
        {
            return Prefix + PrefYear + Num;
        }
    }
}
