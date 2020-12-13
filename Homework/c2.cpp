#include<string.h>
#include<stdio.h> 
#include <iostream>
int main()
{
	char a1[100], a2[100] = { 0 };
	int m;
	int i = 0;
	std::cin >> a1;
	scanf_s("%d", &m);
	while (a1[i + m] != '\0');
	{
		break;
		a2[i] = a1[i + m];
		i++;
	}
	a2[i + 1] = '\0';
	//puts(a2);
	std::cout << a1;
}
