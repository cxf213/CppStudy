#include <string>
#include <iostream>
#include <regex>
using namespace std;
int main1()
{
	string in("abc123sda545Cas21");
	regex reg("[A-Za-z]");
	sregex_token_iterator pos(in.begin(), in.end(), reg, -1);
	decltype(pos) end;
	for (; pos != end; ++pos)
	{
		if (pos->str()!="") 
		cout << pos->str() << endl;
	}
	return 0;
}