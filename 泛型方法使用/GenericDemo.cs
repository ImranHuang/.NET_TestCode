using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型方法使用
{
    /// <summary>
    /// 编写一个出栈入栈的泛型类
    /// 先进后出
    /// </summary>
    public class Mystack<T>
    {
        //准备一个数组类型
        private T[] stack;
        //元素的位置
        private int stackPoint;
        //数据容量
        private int size;

        public Mystack(int size)
        {
            this.size = size;
            this.stack = new T[size];
            this.stackPoint = -1;//因为入栈时索引是从0开始  +1=0

        }

        /// <summary>
        /// 入栈操作
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (stackPoint >= size)
            {
                Console.WriteLine("栈空间已满");
            }
            else
            {
                stackPoint++;
                this.stack[stackPoint] = item;
            }
        }

        public T Pop()
        {
            T date = this.stack[stackPoint];
            stackPoint--;
            return date;
        }

    }
    #region 泛型中default关键字的使用

    public class MyGenericClass<T1, T2>
    {
        private T1 date1;

        private T2 date2;

        public MyGenericClass()
        {
            date1 = default(T1);//如果T1是引用类型，赋值为空；如果是值类型则赋值默认值

            date2 = default(T2);
        }
    }


    #endregion

    #region 泛型约束

    public class MyGenericClass1<T1, T2, T3>
        where T1 : struct//T1必须是值类型
        where T2 : class //解释：T2必须是引用类型，class就是代表引用类型 
        where T3 : new()//解释：T3这个类型中必须有一个无参数的构造方法，这个约束必需放到最后
    {
        /// <summary>
        /// 定义两个属性
        /// </summary>
        public List<T2> ProductList { get; set; }

        public T3 Publisher { get; set; }

        public MyGenericClass1()
        {
            this.ProductList = new List<T2>();
            this.Publisher = new T3();//如果泛型中没有规定这个类型有无参数构造方法是不能直接使用
        }

        public T2 BuyCouese(T1 position)
        {
            dynamic index = position;//dynam是在运行时解析对象类型
            return this.ProductList[index];

        }

    }


    #endregion

    public class Course
    {
        public string CourseName { get; set; }
        public int period { get; set; }
    }

    public class CourseTeacher
    {
        public string TeacherName { get; set; }
        public int period { get; set; }
        public int CourseCount { get; set; }

        public CourseTeacher()
        {
        }


    }

}
