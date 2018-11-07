//http://note.youdao.com/noteshare?id=ce27851319ce756b6d82efb97dea29fe

using System;
using System.Xml;
using System.IO;

/*
遍历元素节点
1:创建xml文档对象并且加载要遍历的文档
2:选择要遍历的XmlNodeList的父元素
3:使用XmlNode实例在foreach中循环遍历



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
    //1创建xml文档对象并加载
    XmlDocument doc = new XmlDocument();
    doc.Load("family.xml");
    
    
    XmlNode node=doc.SelectSingleNode("/Family/Toys");
    //3:删除
    node.RemoveAll();
    doc.Save("familyNew.xml");
    Console.WriteLine("##########使用RemoveAll删除节点#############");
    
    Console.ReadKey();
}
}
}