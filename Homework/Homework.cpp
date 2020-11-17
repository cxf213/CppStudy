#include <stdio.h>
#include <string.h>

int main()
{
	char str1[] = "example 1.";
	char str2[] = "example 2.";
	for (int i = 0; i < strlen(str2);i++) {
		str1[i] = str2[i];
		if (str2[i] == '\0') break;
	}

	printf("%s", str1);
}

