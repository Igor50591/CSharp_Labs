namespace Task1
{ public class program
    {
        public abstract class Pupil
        {
            public abstract void Study();
            public abstract void Read();

            public abstract void Write();

            public abstract void Relax();

        }

        public class ExcelentPupil : Pupil
        {
            public override void Study()
            {
                Console.WriteLine("ExcelentPupil Study");
            }
            public override void Read()
            {
                Console.WriteLine("ExcelentPupil Read");
            }
            public override void Write()
            {
                Console.WriteLine("ExcelentPupil Write");
            }
            public override void Relax()
            {
                Console.WriteLine("ExcelentPupil Relax");
            }
        }
        public class GoodPupil : Pupil
        {
            public override void Study()
            {
                Console.WriteLine("GoodPupil Study");
            }
            public override void Read()
            {
                Console.WriteLine("GoodPupil Read");
            }
            public override void Write()
            {
                Console.WriteLine("GoodPupil Write");
            }
            public override void Relax()
            {
                Console.WriteLine("GoodPupil Relax");
            }
        }

        public class BadPupil : Pupil
        {
            public override void Study()
            {
                Console.WriteLine("BadPupil Study");
            }
            public override void Read()
            {
                Console.WriteLine("BadPupil Rwad");
            }
            public override void Write()
            {
                Console.WriteLine("BadPupil Write");
            }
            public override void Relax()
            {
                Console.WriteLine("BadPupil Relax");
            }
        }

        public class ClassRoom
        {
            Pupil[] ClassRoomWithPupils = new Pupil[4];

            public ClassRoom(params Pupil[] ClassRoomWithPupils)
            {
                if (ClassRoomWithPupils.Length == 4)
                {
                    for (int i = 0; i < ClassRoomWithPupils.Length; ++i)
                    {
                        this.ClassRoomWithPupils[i] = ClassRoomWithPupils[i];
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(ClassRoomWithPupils), "Count of arguments must be equal 4");
                }
            }
            public void demo()
            {
                for (int i = 0; i < ClassRoomWithPupils.Length; ++i)
                {
                    ClassRoomWithPupils[i].Study();
                    ClassRoomWithPupils[i].Read();
                    ClassRoomWithPupils[i].Write();
                    ClassRoomWithPupils[i].Relax();
                }
            }

        }
        public static void Main()
        {
            ExcelentPupil p1  = new ExcelentPupil();
            GoodPupil p2 = new GoodPupil();
            BadPupil p3 = new BadPupil();
            GoodPupil p4 = new GoodPupil();

            ClassRoom ClassP = new(p1, p2, p3, p4);
            ClassP.demo();

        }

    }

}
