//http://note.youdao.com/noteshare?id=113d7ba0b1fe84fc276237e016e59de6

using System;
using System.Xml;
using System.IO;

/*
通过代码创建xml步骤:
1: 引用xml空间
2: 创建xml文档对象
3: 创建第一个行描述并且写入文档
4: 创建根结点
5: 将根结点写入文档，并保存


通过代码追加xml节点
1:创建XmlDocument对象
2:判断是否存在文件，有直接载入，没有创建(参考上面前两步)。使得创建的文档与存在文档关联(Load方法)，并且根结点关联
3:与上面步骤一致

*/

namespace xmlDemo{
class Program{
static void Main(string[] args){
    //1创建xml文档对象
    XmlDocument doc = new XmlDocument();
    XmlElement family;
    //2.加载要追加的文档
    if(File.Exists("family.xml")){
    //如果存在文档对象
    doc.Load("family.xml");
    //关联文件根结点
    family = doc.DocumentElement;
    }else{
    //如果文件不存在，创建
    XmlDeclaration dec=doc.CreateXmlDeclaration("1.0","utf-8",null);
    doc.AppendChild(dec);
    family = doc.CreateElement("Family");
    doc.AppendChild(family);
    }
    

   		//上面追加最重要步骤已经完成,具体追加同上个基础教程
    XmlElement fatherName=doc.CreateElement("Name");
    fatherName.InnerText="薛朝伟";
    family.AppendChild(fatherName);
    
    XmlElement fatherToy=doc.CreateElement("FatherToy");
    
    
    XmlElement toy1=doc.CreateElement("Toy1");
    toy1.SetAttribute("name","薛奕辰");
    toy1.SetAttribute("describe","小淘气");
    fatherToy.AppendChild(toy1);
    
    XmlElement toy2=doc.CreateElement("Toy2");
    toy2.SetAttribute("name","娇娜");
    toy2.SetAttribute("describe","大淘气");
    fatherToy.AppendChild(toy2);
    family.AppendChild(fatherToy);
    
    doc.Save("family.xml");
    Console.WriteLine("保存成功");
    Console.ReadKey();
}
}
}