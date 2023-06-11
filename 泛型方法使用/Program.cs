using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型方法使用
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TestMystack();
            TestGeneric();
            Console.WriteLine(Add<int>(1, 2));
            Console.WriteLine(Add<double>(1.2, 2.3));
         

            Console.ReadLine();
        }



        public void Test()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
        }

        /// <summary>
        /// 测试出栈跟入栈
        /// </summary>
        static void TestMystack()
        {
            //创建泛型对象的对象
            Mystack<int> mystack = new Mystack<int>(5);

            for (int i = 1; i <= 5; i++)
            {
                mystack.Push(i);

               
            }

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(mystack.Pop());
                
            }

            Mystack<string> mystack1 = new Mystack<string>(5);
            mystack1.Push("JAVA");
            mystack1.Push("C#");
            mystack1.Push("C++");
            mystack1.Push("Phthon");
            mystack1.Push("SQL");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(mystack1.Pop());

            }

        }

        /// <summary>
        /// 测试泛型约束
        /// </summary>
        static void TestGeneric()
        {
            MyGenericClass1<int, Course, CourseTeacher> myClass = new MyGenericClass1<int, Course, CourseTeacher>();

            myClass.Publisher = new CourseTeacher { TeacherName = "常老师" };
            myClass.ProductList = new List<Course> {
            new Course{CourseName="C#全栈开发",period=4},
              new Course{CourseName="JAVA开发",period=10},
                new Course{CourseName="SQL语句",period=2}

            };

            //调用方法
            var myCourse = myClass.BuyCouese(0);
            //Console.WriteLine( "我购买的课程是："+myCourse.CourseName.ToString()+"学期："+myCourse.period+"主讲老师："+myClass.Publisher.TeacherName);

            Console.WriteLine($"我购买的课程是：{myCourse.CourseName} 学期：{myCourse.period}  主讲老师: {myClass.Publisher.TeacherName} ");
        }

        static T Add<T>(T a,T b)
            where T:struct
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 + b1;
        }

    }
}
