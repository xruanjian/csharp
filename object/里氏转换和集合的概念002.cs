namespace 里氏转换和集合的概念002
{
    /*
     * 集合和数组的区别：
     * 数组只可以放单一类型元素。长度不可变
     * 集合可以放任意类型的元素。是很多数据的一个集合。长度可变，类型任意
     * 集合的声明(位于Collections包里面)
     * ArrayList list = new ArrayList();
     */
    class program {
        //必须static，否则无法直接使用。因为不static需要实例对象才可以使用
        public static void printList(ArrayList list) {
            for (int j = 0; j < list.Count; j++)
            {
                Console.WriteLine(list[j]);
            }
        }
        static void Main(string[] args) {
            ArrayList list = new ArrayList();
            //添加单个元素
            list.Add(1);
            list.Add("测试字符串");
            //添加集合元素,他和add单个元素的区别，添加单个元素，如果要遍历的画，无法遍历到集合元素内部，这个可以
            list.AddRange(new int[] { 1,10, 11, 12, 13, 14 });
            list.AddRange(list);
            //count方法获取集合长度，不同于数组的Length
            //int i = list.Count;
            printList(list);
            Console.Write("\n\n");
            //list.Clear();清空集合元素
            list.Remove(1);
            printList(list);
            Console.Read();
        }
    
    }

}
