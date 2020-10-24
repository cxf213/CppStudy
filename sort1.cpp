#include<iostream>
#include<string>
#include<math.h>

using namespace std;

void swap(int *a,int *b){
	int *temp =NULL;
	temp=a;
	a=b;
	b=temp;
}

int getlength(int *array)
{
	return (sizeof(*array) / sizeof(array[0]));
}


void Insertsort(int *arr){
	int max=0;
	for(int i=0;i<getlength(arr);i++){
		for(int j=i;j<getlength(arr);j++){
			if(arr[j]>arr[max]) max=j;
		}
		swap(arr[i],arr[max]);
	}
}

int main(){
	double temp=0.0;
	int * arr=new int[10](); 
	
	for(int i=0;i<10;i++){
		temp=sin(i*3.2)*100.0;  //initiate a ramdon(maybe) array;
		arr[i]=temp;
		cout<<arr[i]<<endl;
	}
	cout<<"-------------------------------"<<endl;
	
	Insertsort(arr);
	
	for(int i=0;i<10;i++){
		cout<<arr[i]<<endl;
	}
	
	delete [] arr;
}
