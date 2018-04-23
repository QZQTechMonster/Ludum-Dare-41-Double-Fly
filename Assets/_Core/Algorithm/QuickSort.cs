using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class QuickSort
{

	//快速排序（目标数组，数组的起始位置，数组的终止位置）
	public static void QuickSortFunction(GameObject[] array, int low, int high)
	{
		int keyValuePosition;   //记录关键值的下标

		if (low < high)
		{
			keyValuePosition = keyValuePositionFunction(array, low, high);  //获取关键值的下标（快排的核心）

			QuickSortFunction(array, low, keyValuePosition - 1);    //递归调用，快排划分出来的左区间
			QuickSortFunction(array, keyValuePosition + 1, high);   //递归调用，快排划分出来的右区间
		}
		
	}

	//快速排序的核心部分：确定关键值在数组中的位置，以此将数组划分成左右两区间，关键值游离在外。（返回关键值应在数组中的下标）
	private static int keyValuePositionFunction(GameObject[] array, int low, int high)
	{
		int leftIndex = low;        //记录目标数组的起始位置（后续动态的左侧下标）
		int rightIndex = high;      //记录目标数组的结束位置（后续动态的右侧下标）

		float keyValue = GetValue(array[low]);  //数组的第一个元素作为关键值
        GameObject key = array[low];
        GameObject temp;

		//当 （左侧动态下标 == 右侧动态下标） 时跳出循环
		while (leftIndex < rightIndex)
		{
			while (leftIndex < rightIndex && GetValue(array[leftIndex]) <= keyValue)  //左侧动态下标逐渐增加，直至找到大于keyValue的下标
			{
				leftIndex++;
			}
			while (leftIndex < rightIndex && GetValue(array[rightIndex]) > keyValue)  //右侧动态下标逐渐减小，直至找到小于或等于keyValue的下标
			{
				rightIndex--;
			}
			if (leftIndex < rightIndex)  //如果leftIndex < rightIndex，则交换左右动态下标所指定的值；当leftIndex==rightIndex时，跳出整个循环
			{
				temp = array[leftIndex];
				array[leftIndex] = array[rightIndex];
				array[rightIndex] = temp;
			}
		}

		float tempValue = keyValue;
        temp = key;
        if (tempValue < GetValue(array[rightIndex]) )   
		{
			array[low] = array[rightIndex - 1];
			array[rightIndex - 1] = temp;
			return rightIndex - 1;
		}
		else 
		{
			array[low] = array[rightIndex];
			array[rightIndex] = temp;
			return rightIndex;
		}
	}

    private static float GetValue(GameObject obj) {
        return obj.transform.position.x;
    }
}
