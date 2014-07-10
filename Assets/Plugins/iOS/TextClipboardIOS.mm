
NSString* CreateNSString(const char* string)
{
	return [NSString stringWithUTF8String: string ? string : ""];
}

char* MakeStringCopy(const char* string)
{
	if (string == NULL) return NULL;
	char* res = (char*)malloc(strlen(string) + 1);
	strcpy(res, string);
	return res;
}

extern "C"
{
	void _SetClipboard(const char* text)
	{
		NSString *nsstringText = CreateNSString(text);
		UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
		[pasteboard setValue:nsstringText forPasteboardType:@"public.text"];
	}

	char *_GetClipboard()
	{
		UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
		NSString *string = [pasteboard valueForPasteboardType:@"public.text"];
		return MakeStringCopy([string UTF8String]);
	}
}
