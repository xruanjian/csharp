using System;
/*
惯例，猫叫延时
重点：方法通过属性调用字段，这个是个过渡对象示例，正常开发中，所有字段都定义为私有的。通过属性进行调用
比如CheaseMice()方法使用_miceCount++；语句  会报错，因为他错误调用了保护的字段。正常开发中字段都会私有，都不可以这么调用
*/


namespace 类的学习02属性get和set访问器
{

    class Cat
    {
        //字段成员
        private string _name;
        //........封装为属性成员1Name
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 0 | value.Length > 7)
                {
                    _name = "非法猫";
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int _age;
        //.........封装为属性成员2Age
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                    _age = 0;
                else
                    _age = value;
            }
        }

        private int _miceCount = 0;
        //...........封装为属性成员3
        public int MiceCount { get; set; }
     


        //方法成员
        private void SayHello()
        {
            Console.WriteLine("Hillo,This is mouse:{0}", this._name);
        }

        //方法2: 打招呼后，喵喵叫
        public void Meow()
        {
            //成员方法调用成员方法
            SayHello();
            Console.WriteLine("喵喵…喵喵!");
        }

        //方法3: 抓老鼠,并提示抓了多少只
        public void CheaseMice()
        {
            //重点：方法通过属性调用字段，这个是个过渡对象示例，正常开发中，所有字段都定义为私有的。通过属性进行调用
            //_miceCount++；  会报错，因为他错误调用了保护的字段。正常开发中字段都会私有，都不可以这么调用
            MiceCount++;
            SayHello();
            Console.WriteLine("我已经抓了{0}只老鼠了", MiceCount);
        }

    }



    class program
    {
        //调用演示
        static void Main(string[] args)
        {
            //声明类成员对象
            Cat xiaoW = new Cat();
            xiaoW.Name = "旺财猫";
            xiaoW.Age = 2;


            //xiaoW.SayHello(); 这种不可以直接调用类的私有方法
            //xiaoW.miceCount=9;    也不可以改变类的内部私有变量
            xiaoW.Meow();
            xiaoW.CheaseMice();
            xiaoW.CheaseMice();
            Console.Read();
        }
    }
}
