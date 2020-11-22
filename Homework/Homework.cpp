#include <stdio.h>
#include <math.h>
void getAverge(struct students stu);
void getAverge(struct students stu[], int nums);
struct students {
	double score[5];
	double averge;
};
void getAverge(struct students stu)	
{
	double sum = 0;
	for (int i = 0; i < 5; i++) {sum += stu.score[i];}
	stu.averge = sum / 5;
}
void getAverge(struct students stu[],int nums) {		//第一题
	for (int i = 0; i < nums; i++) getAverge(stu[i]);
}
double getAvergeOfClass(struct students stu[], int classes,int nums) {	//第二题
	double sum = 0;
	for (int i = 0; i < nums; i++) sum += stu[i].score[classes];
	return sum / nums;
}
void getMax(struct students stu[]) {		//第三题
	int maxstu=0,maxclass=0;
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 5; j++) {
			if (stu[i].score[j] > stu[maxstu].score[maxclass]) {
				maxstu = i; maxclass = j;
			}
		}
	}
	printf("%dstu %dclass", maxstu, maxclass);
}
double getAvergeofAverge(struct students stu[], int nums) {
	double sum = 0;
	for (int i = 0; i < nums; i++) { sum += stu[i].averge; }
	return sum / nums;
}
double getdx(struct students stu[], int nums) {		//第四题
	double sum = 0;
	for (int i = 0; i < nums; i++) { sum += pow(stu[i].averge,2)- pow(getAvergeofAverge(stu,nums),2); }
	return sum / nums;
}
int main()
{
	struct students stu[10];
}
