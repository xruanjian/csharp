using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 里氏转换和集合的概念001.cs
{
/*
        在 C# 中，派生类可以包含与基类方法同名的方法。
        基类方法必须定义为 virtual。
        如果派生类中的方法前面没有 new 或 override 关键字，则编译器将发出警告，该方法将有如存在 new 关键字一样执行操作。
        如果派生类中的方法前面带有 new 关键字，则该方法被定义为独立于基类中的方法。
        如果派生类中的方法前面带有 override 关键字，则派生类的对象将调用该方法，而不是调用基类方法。
        可以从派生类中使用 base 关键字调用基类方法。
        override、virtual 和 new 关键字还可以用于属性、索引器和事件中。
        
        
       priavte只能在其自己的定义类中使用，也不能够在其子类中使用    
       而public可以在所有的类中使用    
       protect能够在自已的定义类以及其子类中使用。
    
       is表示类型判断，如果成立则返回一个true，否则False    
       as表示类型判断，如果成立会返回一个成立的对象，否则返回一个null
*/

    //里氏转换的特点：
    /*
     * 1：子类可以副值给父类。实际应用：如果一个地方需要一个父类做参数，可以传递给他一个子类对象。
     * 2：如果一个父类中只装载一个子类。则可以使用强制转换，将父类对象转换为子类对象。
     */
    class Person {
        string _name;
        int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual void sayProperty() {
            Console.WriteLine("我是人类:名字{0},今年{1}岁了 ",this.Name,this.Age);
        }
        public Person(){}
        public Person(string name, int age) { this.Name = name; this.Age = age; }

    }

    class Student:Person{
        int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        
        /*
         在 C# 中，派生类可以包含与基类方法同名的方法。

        基类方法必须定义为 virtual。
        如果派生类中的方法前面没有 new 或 override 关键字，则编译器将发出警告，该方法将有如存在 new 关键字一样执行操作。
        如果派生类中的方法前面带有 new 关键字，则该方法被定义为独立于基类中的方法。
        如果派生类中的方法前面带有 override 关键字，则派生类的对象将调用该方法，而不是调用基类方法。
        可以从派生类中使用 base 关键字调用基类方法。
        override、virtual 和 new 关键字还可以用于属性、索引器和事件中。
         */
        public override void sayProperty()
        {
            ////调用基类上已被其他方法重写的方法
            base.sayProperty();
            Console.WriteLine("同时，我也是一名学生");
        }
        //学生的方法，通报自己学习成绩
        public void  sayScore(){
            Console.WriteLine("我这次考取了{0}分", this.Score);
        }

        public Student(string name, int age, int score) : base(name, age) { this.Score = score; }

        public Student()
        {
            // TODO: Complete member initialization
        }
    
    }

    class Teacher : Person {
        decimal _salary;
            public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
            //老师的方法，通报自己的薪水
            public void saySalary (){
                Console.WriteLine("我是老师，我每个月可以拿到{0}的工资", this.Salary);
            }

            public override void sayProperty()
            {
                base.sayProperty();
                Console.WriteLine("同时我也是一名老师");
            }

            public Teacher(string name, int age, decimal salary) : base(name, age) { this.Salary = salary; }

            public Teacher()
            {
                // TODO: Complete member initialization
            }
    
    }



    class Program
    {
        static void Main(string[] args)
        {
            //根据里氏转换,下面声明不会出错
            Person p1 = new Student("小明",12,100);
            Person p2 = new Teacher("老刘",42,10000m);
            Person[] p = { p1, p2 };

            for (int i = 0; i < p.Length; i++) { 
            //判断元素是哪个，然后根据里氏转换进行转换
                if (p[i] is Teacher) {
                    //使用里氏转换强制转换，然后才可以调用老师的方法
                    Teacher tc = (Teacher)p[i];
                    tc.sayProperty();
                    tc.saySalary();
                    Console.WriteLine("\n");
                }
                else if (p[i] is Student) {
                    //根据里氏转换强制转换后，才可以调用学生的方法。
                    Student ss = (Student)p[i];
                    ss.sayProperty();
                    ss.sayScore();
                    Console.WriteLine("\n");
                }
            
            }

            Console.Read();
        }
    }
}
