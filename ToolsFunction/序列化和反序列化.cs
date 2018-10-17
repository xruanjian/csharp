using System;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
/*

序列化的意义:传输作用


序列化的类型

    二进制（流）序列化
    SOAP序列化
    XML序列化
    
如果我们给自己写的类标识[Serializable]特性，我们就能将这些类序列化。除非类的成员标记了[NonSerializable]，序列化会将类中的所有成员都序列化。

二进制（流）序列化是一种将数据写到输出流，以使它能够用来自动重构成相应对象的机制。二进制，其名字就暗示它的必要信息是保存在存储介质上，而这些必要信息要求创建一个对象的精确的二进制副本。在二进制（流）序列化中，整个对象的状态都被保存起来，而XML序列化只有部分数据被保存起来。为了使用序列化，我们需要引入
*/

class program{
//序列化方法
public static void SerialCreate(string path,Object o){
    using(FileStream fsWriter=new FileStream(path,FileMode.OpenOrCreate)){
    //开始序列化
    BinaryFormatter bf=new BinaryFormatter();
    bf.Serialize(fsWriter,o);
    }
    
    Console.WriteLine("序列化成功");
}


//反序列化方法
public static Object DeSerial(string path){
    using(FileStream fsReader=new FileStream(path,FileMode.Open)){
    BinaryFormatter bf=new BinaryFormatter();
    Console.WriteLine("反序列化成功，返回一个对象，请自己根据里式转换，子类化实例");
    return bf.Deserialize(fsReader);
    } 
}

static void Main(string[] args){
    Person xm=new Person();
    xm.Name="小明";
    xm.Age=12;
    
    SerialCreate("ss.txt",xm);
    Person p = (Person)(DeSerial("ss.txt"));
    Console.WriteLine("反序列化后{0}{1}",p.Name,p.Age);
    Console.Read();
    
    
}
}

[Serializable]
class Person{
     public string Name{get;set;}
     public int Age{set;get;}
}




