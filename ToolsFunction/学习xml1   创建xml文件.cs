//   http://note.youdao.com/noteshare?id=ff9cc8964c5dc4fac861a505131bf17d

using System;
using System.Xml;

/*
通过代码创建xml步骤:
1: 引用xml空间
2: 创建xml文档对象
3: 创建第一个行描述并且写入文档
4: 创建根结点
5: 将根结点写入文档，并保存

*/

namespace xmlDemo{
class Program{
static void Main(string[] args){
    //2创建xml文档对象
    XmlDocument doc = new XmlDocument();
    //3添加xml文档第一句描述
    XmlDeclaration des = doc.CreateXmlDeclaration("1.0","utf-8",null);
    doc.AppendChild(des);
    //4创建一个根结点
    XmlElement family = doc.CreateElement("Family");
    doc.AppendChild(family);
    
    
    XmlElement item1 = doc.CreateElement("Name");
    item1.InnerText ="薛奕辰";
    family.AppendChild(item1);
    
    XmlElement item2 = doc.CreateElement("Toys");
    
    XmlElement item21 =doc.CreateElement("车");
    
    XmlElement item211=doc.CreateElement("玩具车");
    item211.SetAttribute("Name","火车一号");
    item211.SetAttribute("Attr","隧道上可以跑的火车");
    item21.AppendChild(item211);
    item2.AppendChild(item21);
    
    XmlElement item22=doc.CreateElement("飞机");
    XmlElement item221=doc.CreateElement("玩具飞机");
    item221.SetAttribute("Name","飞机1号");
    item221.SetAttribute("Des","小黄人样子的直升机");
    item22.AppendChild(item221);
    item2.AppendChild(item22);
    
    
    family.AppendChild(item2);
    
    
    
    
    
    doc.Save("family.xml");
    Console.WriteLine("保存成功");
    Console.ReadKey();
}
}
}