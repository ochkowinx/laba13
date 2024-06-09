using Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба13
{
    public class Shrub : Plant, IInit, ICloneablePlant
    {
        private bool hasSpines;
        private static readonly Random random = new Random();

        public bool HasSpines
        {
            get { return hasSpines; }
            set { hasSpines = value; }
        }

        public Shrub() : base()
        {
        }

        public Shrub(string name, string color, int id, double height) : base(name, color, id, height)
        {
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Есть ли колючки у кустарника? (true/false): ");
            bool.TryParse(Console.ReadLine(), out bool spines);
            HasSpines = spines;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            HasSpines = random.Next(2) == 1;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Shrub other = (Shrub)obj;
            return HasSpines == other.HasSpines;
        }

        public new object Clone()
        {
            return (Shrub)base.Clone();
        }

        public override string ToString()
        {
            return base.ToString() + $", HasSpines: {HasSpines}";
        }
    }
}
