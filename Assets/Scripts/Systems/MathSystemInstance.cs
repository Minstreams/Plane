using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameSystem
{
    /// <summary>
    ///  数学系统，封装重要的计算方法
    /// </summary>
    public static class MathSystem
    {
        //暂时没看到参数需求

        /// <summary>
        /// 上三角矩阵映射，将a(0~n)和b(0~n)映射到(0~n*(n-1)/2)并满足交换律
        /// </summary>
        /// <param name="a">参数1</param>
        /// <param name="b">参数2 ！=参数1</param>
        /// <returns></returns>
        public static int UpTriangleIndex(int a, int b)
        {
            int c;
            if (a > b)
            {
                c = a;
                a = b;
            }
            else
            {
                c = b;
            }
            return (c * (c - 1) / 2 + a);
        }
    }
}
