## 一:ArrayList和Hashtable     

-------


#### [ArrayList使用代码](https://github.com/xruanjian/csharp/blob/master/CollectionsAndLSP/里氏转换和集合的概念002.cs)


#### [Hashtable使用代码](https://github.com/xruanjian/csharp/blob/master/CollectionsAndLSP/里氏转换和集合的概念003.cs)

集合和数组的区别：  

- 数组只可以放单一类型元素。长度不可变     
- 集合可以放任意类型的元素。是很多数据的一个集合。长度可变，类型任意    
- 集合的声明(位于Collections包里面)    



###   1:使用    


###### ArrayList集合的使用方式:
```
ArrayList  list=new ArrayList();
list.Add(1);
list.Add("字符串");
//可以添加任何元素，甚至可以添加自身
list.AddRange(list);
list.AddRange(new int[]{3,5,8,18});

```
###### Hashtable集合的使用方式:

```
Hashtable ht=new Hashtable();
ht.Add(1,"第一个元素");
ht.Add("第二个元素",123456);



```
 ~~ht.Add(1,"这个元素没法添加，因为键重名，不允许，编译出错");~~     

可以看出来:
Hashtable相对于ArrayList，他采用键值对的方式来存储数据。
##### Hashtable键唯一，否则出错

-------    

#### 2:遍历
> ArrayList和Hashtable都不像数组，没有Length属性，用Count属性获取元素个数。

遍历ArrayList的元素:
```
public static void printList(ArrayList list) {
            for (int j = 0; j < list.Count; j++)
            {
                Console.WriteLine(list[j]);
            }
        }
```

 遍历Hashtable
```
static void printHashtable(Hashtable ht) {
            //利用键值进行遍历
            foreach (var item in ht.Keys)
            {
                Console.WriteLine("*****Key为：{0}*****值为：{1}******", item, ht[item]);
            }
        
        }
```
#### 3:学习他们的各个使用方法

ArrayList和Hashtable的区别：     
         * ArrayList和Hashtable都可以存放任意类型数据
         * 区别：ArrayList存放的是单个数据集合。Hashtable存放的是键值对的集合
         * ArrayList可以for进行遍历，Hashtable只可以用foreach遍历。
         * ArrayList访问成员使用list[下标号]访问
         * Hashtable访问成员使用ht[要访问值对应的key]

-------
常用函数，参考最上面示例代码:

######  ArrayList和Hashtable的常用函数：
Add       AddRange    Remove    RemoveAt
RemoveRange    Insert   InsertRange  Sort
Reserve
      Contains()   Add     Remove       GetType     Count   Equals    ContainsKey     ContainsValue
           Clear            Clone
         
#### 4:实例
[利用Hashtable实现简体转繁体](https://github.com/xruanjian/csharp/blob/master/CollectionsAndLSP/集合应用001Hashtable繁简转换.cs)

将一个字符数组转换为字符串
```
char[] ch=new char[]{‘读’,‘d’,‘s’,‘d’,‘f’,‘a’};     
string str=new string(ch);
```

## 二: List <T>和Dictionary <Key,Value>
-------
*泛型，即“参数化类型”。一提到参数，最熟悉的就是定义方法时有形参，然后调用此方法时传递实参。那么参数化类型怎么理解呢？顾名思义，就是将类型由原来的具体的类型参数化，类似于方法中的变量参数，此时类型也定义成参数形式（可以称之为类型形参），然后在使用/调用时传入具体的类型（类型实参）。*



> 装箱和拆箱:    
装箱:是指将值类型转换为引用类型    
拆箱:指的是将引用类型转换为值类型


List<T>和Dictionary<Key,Value>泛型集合相对于普通ArrayList和Hashtable,对传递的参数进行了限制。泛型相比普通集合，不需要频繁的拆箱装箱，大大增强了效率，大多数情况下，泛型执行的更好并且更安全。

例如，声明:
```
//声明一个List泛型集合
List<int> list = new List <int>();
//声明一个词典集合
Dictionary <int,string> dict=new Dictionary <int,string>();
```



