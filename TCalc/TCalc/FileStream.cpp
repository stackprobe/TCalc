#include "all.h"

FILE *rfopen(char *file, char *mode)
{
	for(int retry = 0; ; retry++)
	{
		// fopen() は引数に問題が無くても、稀に失敗することがある。
		// 適当に間隔を空けて何度かリトライする。
		FILE *fp = fopen(file, mode); // file == "" のとき NULL を返す。

		if(fp != NULL)
		{
			if(retry)
				cout("File opened at %u-th retrial.\n", retry);

			return fp;
		}
		if(retry == 20)
		{
			cout("Can not open file \"%s\" as \"%s\" mode.\n", file, mode);
			return NULL;
		}
		Sleep(100);
	}
}
FILE *fileOpen(char *file, char *mode)
{
	FILE *fp = rfopen(file, mode);

	errorCase(!fp);
	return fp;
}
void fileClose(FILE *fp)
{
	errorCase(fclose(fp)); // ? 失敗
}

__int64 getFileSize(FILE *fp)
{
	errorCase(_fseeki64(fp, 0I64, SEEK_END)); // ? 失敗
	__int64 size = _ftelli64(fp);
	errorCase(size < 0); // ? 失敗
	return size;
}
__int64 getFileSize(char *file)
{
	FILE *fp = fileOpen(file, "rb");
	__int64 size = getFileSize(fp);
	fileClose(fp);
	return size;
}
void setFileSize(char *file, __int64 size)
{
	FILE *fp = fileOpen(file, "ab");
	int fh = _fileno(fp);

	errorCase(_chsize_s(fh, size)); // ? 失敗

	fileClose(fp);
}

int readChar(FILE *fp)
{
	int chr = fgetc(fp);

	errorCase(chr == EOF && ferror(fp)); // ? 失敗
	return chr;
}
char *readLine(FILE *fp)
{
	autoList<char> *buff = new autoList<char>();

	for(; ; )
	{
		int chr = readChar(fp);

		if(chr == '\r')
			continue;

		if(chr == '\n')
			break;

		if(chr == EOF)
		{
			if(!buff->GetCount())
			{
				delete buff;
				return NULL;
			}
			break;
		}
		buff->AddElement(chr);
	}
	buff->AddElement('\0');
	char *line = buff->UnbindBuffer();
	delete buff;
	return line;
}
char *readLine(char *file)
{
	FILE *fp = fileOpen(file, "rt");
	char *line = readLine(fp);
	fileClose(fp);
	return line;
}
char *nnReadLine(FILE *fp)
{
	char *line = readLine(fp);
	errorCase(!line);
	return line;
}
char *nnReadLine(char *file)
{
	char *line = readLine(file);
	errorCase(!line);
	return line;
}

autoList<char *> *readLines(char *file)
{
	FILE *fp = fileOpen(file, "rt");
	autoList<char *> *lines = new autoList<char *>();

	for(; ; )
	{
		char *line = readLine(fp);

		if(!line)
			break;

		lines->AddElement(line);
	}
	fileClose(fp);
	return lines;
}
char *readText(char *file)
{
	cout("< %s\n", file); // app

	autoList<uchar> *text = readBinary(file);
	text->AddElement(0x00);
	char *out = (char *)text->UnbindBuffer();
	delete text;
	return out;
}

void writeChar(FILE *fp, int chr)
{
	errorCase(fputc(chr, fp) == EOF); // ? 失敗
}
void writeToken(FILE *fp, char *token)
{
	for(char *p = token; *p; p++)
	{
		writeChar(fp, *p);
	}
}
void writeToken(char *file, char *line)
{
	cout("> %s\n", file); // app

	FILE *fp = fileOpen(file, "wt");
	writeToken(fp, line);
	fileClose(fp);
}
void writeToken_x(FILE *fp, char *token)
{
	writeToken(fp, token);
	memFree(token);
}
void writeLine(FILE *fp, char *line)
{
	writeToken(fp, line);
	writeChar(fp, '\n');
}
void writeLine_x(FILE *fp, char *line)
{
	writeLine(fp, line);
	memFree(line);
}
void writeLine(char *file, char *line)
{
	FILE *fp = fileOpen(file, "wt");
	writeLine(fp, line);
	fileClose(fp);
}
void writeLine_cx(char *file, char *line)
{
	writeLine(file, line);
	memFree(line);
}

void fileSeek(FILE *fp, int origin, __int64 offset) // origin, offset の並びは fseek() と逆
{
	errorCase(_fseeki64(fp, offset, origin)); // ? 失敗
}
void fileRead(FILE *fp, void *block, int size)
{
	if(size)
	{
		errorCase(fread(block, 1, size, fp) != size); // ? 失敗 || size バイト読み込む前に EOF に到達
		errorCase(ferror(fp));
	}
}
void fileWrite(FILE *fp, void *block, int size)
{
	if(size)
	{
		errorCase(fwrite(block, 1, size, fp) != size); // ? 失敗
		errorCase(ferror(fp));
	}
}

void readBlock(char *file, void *block, int size)
{
	FILE *fp = fileOpen(file, "rb");
	fileRead(fp, block, size);
	fileClose(fp);
}
void writeBlock(char *file, void *block, int size, int addMode)
{
	FILE *fp = fileOpen(file, addMode ? "ab" : "wb");
	fileWrite(fp, block ,size);
	fileClose(fp);
}

autoList<uchar> *readBinary(char *file)
{
	__int64 sz = getFileSize(file);
	errorCase(INT_MAX < sz);
	int size = (int)sz;
	void *block = memAlloc(size);
	readBlock(file, block, size);
	return new autoList<uchar>((uchar *)block, size);
}
