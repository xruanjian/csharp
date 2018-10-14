class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText(@"C:\Users\Administrator\Desktop\数据.txt", Encoding.UTF8);
            //采用泛型集合统计
            Dictionary<char, int> strDict = new Dictionary<char, int>();
            //采用循环，将文本字符串每个字符和频率统计到词典中
            for(int i=0;i<str.Length;i++){
                if(strDict.ContainsKey(str[i])){
                    strDict[str[i]]++;
                }else{
                    strDict.Add(str[i],1);
                }
            }
            //注意泛型Dictinary的遍历
            foreach(KeyValuePair<char,int> kv in strDict){
                Console.WriteLine("---{0}---------------出现次数{1}", kv.Key, kv.Value);
            }

            Console.Read();
        }
    }
