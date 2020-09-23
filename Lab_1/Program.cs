using System;
using System.Collections.Generic;


namespace Lab_1
{
    class Program
    {
  

        private List<Student> list = new List<Student>();
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.inizialaze();
            program.menu();
        }

        private void menu()
        {
         
            int choose;
            bool go = true;
            while (go)
            {
                Console.WriteLine("Выберите действие:\n" +
              "1 - добавить студента\n" +
              "2 - установить оценку по индексу предмета(индекс состоит из 3-х чисел и  указан после предмета)\n" +
              "3 - получить оценку по индексу предмета\n" +
              "4 - сравнить двух студентов по оценкам\n" +
              "5 - вывести список всех студентов и их оценки\n" +
              "6 - выход\n");
                string str = Console.ReadLine();
               
                int.TryParse(str, out choose);
                Console.WriteLine();
                switch (choose)
               {
                case 1:
                        addStudent();
                        break;
                case 2:
                        setMark();
                        break;
                case 3:
                        getMark();
                        break;
                case 4:

                       Console.WriteLine("Разница баллов:" );
                        compareStudents();
                        break;
                case 5:
                        printAll();
                        break;
                case 6:
                        go = false;
                        break;
               
                }
            }
            
        }
        private Student findStudent()
        { 
            int number = 0;
            while (true)
            {
             Console.WriteLine("Введите номер зачетки");
                        string str = Console.ReadLine();
                       
                        try
                        {
                            number = Convert.ToInt32(str);
                             break;
                        }
                        catch
                        {
                            Console.WriteLine("Попробуйте еще раз");
                        }
            }
           

            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].Number == number)
                {
                    return list[i];
                }
            }
            return null;
        }
        private Student findNumber()
        {
            Student st = findStudent();
            while (true)
            {
                if (st == null)
                {
                    Console.WriteLine("Неверный номер зачетки");
                    Console.WriteLine("Попробуйте еще раз");
                    st = findStudent();
                }
                else
                {

                    break;
                }
            }
           
            return st;
        }
        private void printAll()
        {
            foreach(Student i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }

        private void compareStudents()
        {
            Console.WriteLine("Поиск студента 1");
            Student st1 = findNumber();
            Console.WriteLine("Поиск студента 2");
            Student st2 = findNumber();

            int[] arr = new int [10];

            for(int i = 0; i < arr.Length; i++)
            {
                int temp = st1.Mark[i] - st2.Mark[i];
                if (temp > 0)
                {
                    arr[i] = temp;
                } else
                {
                    arr[i] = st2.Mark[i] - st1.Mark[i];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(st1.subj[i] + "\t[" + arr[i] + ']');
            }
        }
        private int findIndex()
        {
            string str;
            int index = 0;
            while (true)
            {
                Console.WriteLine("Введите индекс предмета: ");
                str = Console.ReadLine();
                try
                {
                    index = Convert.ToInt32(str);
                    break;
                }
                catch
                {
                    Console.WriteLine("Индекс предмета введен неверно! Попробуйте еще раз");
                }
            }
                return index;
        }
        private void getMark()
        {
            Student st = findNumber();
            int index = findIndex();
            bool go = true;
            while (go)
            {
                for (int i = 0; i < st.Mark.Length; i++)
                {
                    if (st.index[i] == index)
                    {
                        go = false;
                        break;
                    }

                }
                if (go)
                {
                    Console.WriteLine("Индекс предмета неверный, попробуйте еще раз");
                    index = findIndex();
                }

            }
            int indexForFound = index % 100 - 1;

            Console.WriteLine("Оценка: " + st.Mark[indexForFound]);
            Console.WriteLine();
            
        }
     
        private void setMark()
        {
           
            Student st = findNumber();
            int index = findIndex();
            string str;
            bool go = true;
            while (go)
            {
                for (int i = 0; i < st.Mark.Length; i++)
                {
                    if (st.index[i] == index)
                    {
                        go = false;
                        break;
                    }

                }
                if (go)
                {
                    Console.WriteLine("Индекс предмета неверный, попробуйте еще раз");
                    index = findIndex();
                }

            }
            int indexForChange = index % 100 - 1;
            Console.WriteLine("Введите оценку в пределах от 60 до 100");
            while (true)
            {
        
                str = Console.ReadLine();
                try
                {
                    index = Convert.ToInt32(str);
                }
                catch
                {
                    Console.WriteLine("Некорректно. Введите оценку в пределах от 60 до 100");
                }
                if( index > 59 && index < 101)
                { 
                    st.Mark[indexForChange] = index;
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректно. Введите оценку в пределах от 60 до 100");
                }
            }
           
            st.Avg = st.setAvg();
            Console.WriteLine("Оценка успешно изменена!\n");
           
        }

        private void addStudent()
        {
            string str;
            Console.WriteLine("Введите ФИО студента( не может содержать цифр)\n" +
                "После ввода должна повиться надпись о успешной операции. Если ее нет - повторите ввод!");
            string name;
            while (true)
            {
                str = Console.ReadLine();
                if(str != null && str != "" && checkString(str))
                { 
                name = str;
                break;
                }

            }
            Console.WriteLine("Успешно!");
            Console.WriteLine("Введите номер зачетки студента(8 цифр)\n" +
                "После ввода должна повиться надпись о успешной операции. Если ее нет - повторите ввод!");
            
            int number;
            while (true)
            {
                str = Console.ReadLine();
                int.TryParse(str, out number);
                if (number > 9999999 && number < 100000000)
                {       
                    break;
                }

            }
            Console.WriteLine("Успешно!");
            Console.WriteLine("Введите курс студента(1-6 курс)\n" +
               "После ввода должна повиться надпись о успешной операции. Если ее нет - повторите ввод!");
            byte course;
            while (true)
            {
                str = Console.ReadLine();
                byte.TryParse(str, out course);
                if (course > 0 && course < 7)
                {
                    break;
                }

            }

            list.Add(new Student(name, number, course, generateMark()));

        }

        private bool checkString(string A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= '0' && A[i] <= '9')
                {
                    return false;
                }
            }
            return true;
        }

        private void inizialaze()
        {
            String[] name = { "Афанасьева Анна Николаевна", "Бондарь Олег Владимирович", "Воропаева Ксения Андреевна", "Гречмак Дмитрий Викторович" };
            int[] number = { 10001001, 10001002, 10001003, 10001004 };
            byte[] course = { 3, 3, 3, 3 };

            for (int i = 0; i < name.Length; i++)
            {
                list.Add(new Student(name[i], number[i], course[i], generateMark()));
            }
           
        }

        private int[] generateMark()
        {

            Random rnd = new Random();
            
            int[] mark = new int[10];
            for(int i = 0; i < 10; i++)
            {
                mark[i] = rnd.Next(60, 100);
            }

            return mark;
        }



    }

    class Student
    {
        public int[] index = { 301, 302, 303, 304, 305, 306, 307, 308, 309, 310 };
        public String[] subj = { "301 СПЗ ", "302 АК  ", "303 КСх ", "304 СИиИК", "305 МодС", "306 ЛМод", "307 СКБД", "308 I-тех", "309 ТПInt", "310 СМС " };
        private String name;
        private int number;
        private byte course;
        private float avg;
        private int[] mark;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public int[] Mark 
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }
        public float Avg
        {
            get
            {
                return avg;
            }

            set
            {
                avg= value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public byte Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
            }
        }

        public Student(string name, int number, byte course, int[] mark)
        {
            this.name = name;
            this.number = number;
            this.course = course;
            this.mark = mark;
            avg = setAvg();
            
        }
        public float setAvg ()
        {
            float sum = 0;
            foreach(int i in mark)
            {
                sum += i;
            }
           float result = sum / mark.Length;
            return result;
        }

        public override string ToString()
        {
            string str = "ФИО: " + name + '\n' + "Номер зачетки: " + number + '\n' + "Курс: " + course + '\n' + "Средний балл: " + avg + '\n' + "Оценки: "+ '\n'+ markPrint() + '\n' + '\n';
            return str;
        }

        private string markPrint()
        {
            string str = "";
            for (int i = 0; i < subj.Length; i++)
            {
                str += subj[i] + "\t[" + mark[i] + ']' + '\n';
            }
            return str;
        }
    }
}
