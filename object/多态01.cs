using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态学习
{
    /*
     * 多态指同一个实体同时具有多种形式。它是面向对象程序设计(OOP)的一个重要特征。
     * 如果一个语言只支持类而不支持多态，只能说明它是基于对象的，而不是面向对象的。
     * C++中的多态性具体体现在运行和编译两个方面。
     * 运行时多态是动态多态，其具体引用的对象在运行时才能确定。编译时多态是静态多态，在编译时就可以确定对象使用的形式。
     * 
     * 多态:同一操作作用于不同的对象，可以有不同的解释，产生不同的执行结果。在运行时，可以通过指向基类的指针，来调用实现派生类中的方法
     * 
     * C++中，实现多态有以下方法:虚函数，抽象类，覆盖，模板(重载和多态无关)。

        OC中的多态:不同对象对同一消息的不同响应.子类可以重写父类的方法

        多态就是允许方法重名 参数或返回值可以是父类型传入或返回。
     * 
     * 抽象方法是只有定义、没有实际方法体的函数，它只能在抽象函数中出现，并且在子类中必须重写;虚方法则有自己的函数体，已经提供了函数实现，但是允许在子类中重写或覆盖。
       重写的子类虚函数就是被覆盖了。
     */

    /*
     Csharp多态通过：
     * 虚方法      抽象类      接口    来实现。
     * 1：:抽象成员必须标记为abstract，并且不能有任何实现.
     * 注意abstract对字段无效，比如，public  abstract string name;这样错误
     * 2：抽象成员必须在抽象类中
     * 3：抽象类不能实例化
     * 4：子类继承抽象类后，必须把父类中的所有抽象成员都重写。（除非子类也是一个抽象成员，可以不重写）
     * 5：抽象成员的访问修饰符不可以为private
     * 6：在抽象类中可以包含实例成员。并且抽象类的实例成员可以不被子类重写。
     * 7：抽象类是有构造函数的，虽然不能被实例化
     * 8：如果父类的抽象方法中有参数，那么：
     * 继承这个抽象父类的子类在重写父类的方法的时候必须传入一致对应的参数。
     * 如果抽象父类的抽象方法有返回值，那么子类在重写抽象方法的时候，也必须传回返回值。
     * 
     * ==============================================================================
     * 使用场景：
     * 
     * 如果父类中的方法有默认的实现，并且父类需要被实例化，这时候可以考虑将父类定义为一个普通类，用虚方法来实现多态
     * 
     * 如果父类中的方法没有默认实现，父类也不需要被实例化，则可以将该类定义为抽象类
     */
    
    //定义一个抽象类
    public abstract class Animal
    {
        public abstract void Sleep();
        public abstract void Eat();

        public void cry() { Console.WriteLine("抽象方法中的实例成员Cry"); }
        
    }

    class Cat : Animal {
        public override void Sleep()
        {
            Console.WriteLine("Cat is sleeping");
        }

        public override void Eat()
        {
            Console.WriteLine("Cat eating");
        }
    }
    class Person:Animal {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        //采用虚方法尿尿，来提供子类重载
        public virtual void Piss() {
            Console.WriteLine("尿尿");
        }

        public virtual void Cry() { Console.WriteLine("人类会哭泣"); }

        //继承抽象类，抽象类的方法必须实现
        public override void Sleep()
        {
            Console.WriteLine("Person Sleeping");
        }

        public override void Eat()
        {
            Console.WriteLine("Person Eatting");
        }
    }

    class Boy :Person{
        public override void Piss() {
            Console.WriteLine(@"（通过继承虚方法，实现多态：尿尿重载）男孩站着尿尿");
        }
    }

    class Girl : Person {
        public override void Cry()
        {
            Console.WriteLine("女孩子在哭泣");
        }
        public override void Eat()
        {
            Console.WriteLine("女孩子什么都吃");
        }
        public override void Piss()
        {
            Console.WriteLine("女孩蹲着尿尿");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //可以使用下面的定义来实现试验多态。
            Person p1 = new Boy();
            Person P2 = new Girl();
            //注意这种格式Animal p3隔代继承后，实例化无法使用Animal没有的piss方法
            Animal p3=new Boy();
            Animal c1 = new Cat();

            p1.Eat();
            p1.Piss();
            p1.Cry();       //因为子类没有重写virtual方法，所以继承父类的Cry
            p1.Sleep();
            P2.Eat();
            P2.Piss();
            P2.Sleep();
            P2.Cry();
            p3.Eat();
            p3.Sleep();
            //p3.piss();    //会出错。因为piss方法不存在在Animal类中

            //不会出错，会打印Animal的实例成员方法Cry，但是不会继承Person类中的方法Cry。为什么，因为定义使用Animal p3=new Boy();
            p3.cry();      
            c1.Eat();

            Console.Read();
            
        }
    }
}
